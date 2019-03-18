using System;
using System.Collections.Generic;
using System.Security.Claims;
using CommonModels.Entity;
using CommonModels.Identity;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Groove.Domain;
using Groove.Domain.Context;

namespace Groove.Services
{
    public partial class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IIdentityRepository identityRepository, IHttpContextAccessor httpContextAccessor)
        {
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public AuthTokenModel Registration(ReistrationModel reg)
        {
            try
            {
                RegistrationModelChecker.Check(reg);
                if (GetUser(reg.Email) != null)
                {
                    return new AuthTokenModel(0, string.Empty, "Username alredy used!", string.Empty);
                }
                _identityRepository.Registration(reg.Email, reg.Password);
                GrooveAppContext.Id = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name);
                return Autorize(reg.Email, reg.Password);
            }
            catch (Exception e)
            {
                return new AuthTokenModel(0, string.Empty, e.Message, string.Empty);
            }
        }

        public AuthTokenModel Autorize(string username, string password)
        {
            var authTokenModel = GetAuthTokenModel(username, password);
            if (authTokenModel == null)
            {
                return null;
            }
            return authTokenModel;
        }

        private AuthTokenModel GetAuthTokenModel(string username, string password)
        {
            var user = GetUser(username);
            if (user == null)
            {
                return new AuthTokenModel(0, string.Empty, "User not found", string.Empty);
            }
            if (user.Password != password)
            {
                return new AuthTokenModel(0, string.Empty, "Invalid password", string.Empty);
            }
            var claims = new List<Claim>
                         {
                             new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                         };
            var identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType); 
            var encodedJwt = TokenHelper.GetToken(identity.Claims);
            return new AuthTokenModel(user.Id, user.Token, "Success", user.Login);
        }

        public User GetUser(string userName)
        {
            return _identityRepository.GetUser(userName);
        }

        public User GetUserById(long userId)
        {
            return _identityRepository.GetUserById(userId);
        }

        public AuthTokenModel ValidateToken(string token)
        {
            try
            {
                TokenHelper.ValidateToken(token);
                var user =  _identityRepository.GetUserByToken(token);
                if (user != null)
                {
                    return new AuthTokenModel(user.Id, user.Token, "Success", user.Login);
                }
                return new AuthTokenModel(0, string.Empty, "User not found", string.Empty);
            }
            catch (Exception ex)
            {
                return new AuthTokenModel(0, string.Empty, ex.Message, string.Empty);
            }
        }
    }
}

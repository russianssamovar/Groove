using System;
using System.Collections.Generic;
using System.Security.Claims;
using CommonModels.Entity;
using CommonModels.Identity;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Groove.Domain.Services
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
                    return null;
                }
                _identityRepository.Registration(reg.Email, reg.Password);
                return Autorize(reg.Email, reg.Password);
            }
            catch (Exception e)
            {
                return new AuthTokenModel
                       {
                           Access_token = "",
                           Message = e.Message
                       };
            }
        }

        public AuthTokenModel Autorize(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }

            var encodedJwt = TokenHelper.GetToken(identity.Claims);

            return new AuthTokenModel
                   {
                       Access_token = encodedJwt,
                       UserName = identity.Name
                   };
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
            TokenHelper.ValidateToken(token);
            return new AuthTokenModel
                   {
                       Access_token = token
                   };
          
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = GetUser(username);

            if (user == null)
            {
                return null;
            }

            if (user.Password != password)
            {
                return null;
            }

            var claims = new List<Claim>
                         {
                             new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                         };

            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType); 
        }
    }
}

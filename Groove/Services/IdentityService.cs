using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommonModels;
using CommonModels.OptionsModels;
using DBRepository.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Groove.Services
{
    public partial class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
        }

        public AuthToken Autorize(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthToken
                   {
                       Access_token = encodedJwt,
                       UserName = identity.Name
                   };
        }
        
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = GetUser(username);
            if (user.Password != password)
            {
                return null;
            }
            if (user != null)
            {
                var claims = new List<Claim>
                             {
                                 new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                             };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
 
            return null;
        }

        public User GetUser(string userName)
        {
            return _identityRepository.GetUser(userName);
        }
    }
}

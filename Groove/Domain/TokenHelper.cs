using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using CommonModels.OptionsModels;
using Microsoft.IdentityModel.Tokens;

namespace Groove.Domain
{
    public class TokenHelper
    {
        public static string GetToken(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
                   {
                       ValidateLifetime = true, 
                       ValidateAudience = true, 
                       ValidateIssuer = true,   
                       ValidIssuer = AuthOptions.ISSUER,
                       ValidAudience = AuthOptions.AUDIENCE,
                       IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                   };
        }
    }
}
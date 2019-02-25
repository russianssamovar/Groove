using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CommonModels.OptionsModels
{
    public class AuthOptions
    {
        public const string ISSUER = "Groove"; 
        public const string AUDIENCE = "localhost"; 
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 1000; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

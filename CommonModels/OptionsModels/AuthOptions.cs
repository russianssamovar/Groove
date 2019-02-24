using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CommonModels.OptionsModels
{
    public class AuthOptions
    {
        public const string ISSUER = "Groove"; // издатель токена
        public const string AUDIENCE = "localhost"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1000; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

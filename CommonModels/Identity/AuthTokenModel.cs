
namespace CommonModels.Identity
{
    public class AuthTokenModel
    {
        public AuthTokenModel(long userId, string accessToken, string message, string userName)
        {
            UserId = userId;
            Message = message;
            UserName = userName;
            AccessToken = accessToken;
        }

        public long UserId { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
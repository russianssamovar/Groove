using CommonModels;

namespace Groove.Services
{
    public interface IIdentityService
    {
        AuthToken Autorize(string username, string password);
        User GetUser(string userName);
    }
}
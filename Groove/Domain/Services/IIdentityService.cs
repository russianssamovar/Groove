using CommonModels.Entity;
using CommonModels.Identity;

namespace Groove.Domain.Services
{
    public interface IIdentityService
    {
        AuthTokenModel Autorize(string username, string password);
        AuthTokenModel Registration(ReistrationModel reg);
        User GetUser(string userName);
        User GetUserById(long userId);

    }
}
using CommonModels;
using CommonModels.Identity;

namespace Groove.Domain.Services
{
    public interface IIdentityService
    {
        AuthToken Autorize(string username, string password);
        AuthToken Registration(ReistrationModel reg);
        User GetUser(string userName);
    }
}
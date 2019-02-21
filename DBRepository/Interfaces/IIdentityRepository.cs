using CommonModels;

namespace DBRepository.Interfaces
{
    public interface IIdentityRepository
    {
        User GetUser(string userName);
        bool Registration(string userName, string password);
        User GetUserById(long userId);
    }
}

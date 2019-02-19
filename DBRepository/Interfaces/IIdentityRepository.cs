using System.Threading.Tasks;
using CommonModels;

namespace DBRepository.Interfaces
{
    public interface IIdentityRepository
    {
        User GetUser(string userName);
        bool Reistration(string userName, string password);
    }
}

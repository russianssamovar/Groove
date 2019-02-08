using System.Threading.Tasks;
using CommonModels;

namespace DBRepository.Interfaces
{
    public interface IIdentityRepository
    {
		Task<User> GetUser(string userName);
    }
}

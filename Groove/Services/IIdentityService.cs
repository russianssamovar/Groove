using System.Security.Claims;
using System.Threading.Tasks;
using CommonModels;

namespace Groove.Services
{
    public interface IIdentityService
    {
        Task<User> GetUser(string userName);
        User GetUser(string userName, string password);
        bool Reistration(string userName, string password);
    }
}
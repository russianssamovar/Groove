using System.Threading.Tasks;
using CommonModels;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAccounts(long accountId);
    }
}
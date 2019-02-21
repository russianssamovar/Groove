using System.Collections.Generic;
using System.Threading.Tasks;
using CommonModels;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts(long userId);
        Task<bool> Add(Account account);
    }
}
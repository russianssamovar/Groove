using CommonModels.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts(long userId);
        Task<bool> Add(Account account);
    }
}
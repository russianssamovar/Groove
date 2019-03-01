using CommonModels.Entity;
using System.Collections.Generic;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts(long userId);
        bool Add(long userId, Account account);
    }
}
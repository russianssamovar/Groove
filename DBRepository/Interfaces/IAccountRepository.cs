using CommonModels.Entity;
using System.Collections.Generic;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts(long userId);
        bool Add(long userId, Account account);
        Account GetAccount(long userId, string socialId, AccountType type);
        IEnumerable<Account> UpdateAccounts(long userId, IEnumerable<Account> accounts);
    }
}
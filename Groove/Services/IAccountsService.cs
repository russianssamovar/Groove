using CommonModels.Entity;
using System.Collections.Generic;

namespace Groove.Services
{
    public interface IAccountsService
    {
        IEnumerable<Account> ListAccounts();
        void AddAccount(Dictionary<string, string> addParams, AccountType type);
    }
}
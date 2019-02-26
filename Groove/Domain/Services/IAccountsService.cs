using CommonModels.Entity;
using System.Collections.Generic;

namespace Groove.Domain.Services
{
    public interface IAccountsService
    {
        IEnumerable<Account> ListAccounts();
        void AddAccount(string token);
    }
}
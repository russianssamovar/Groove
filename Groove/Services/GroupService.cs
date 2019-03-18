using System.Collections.Generic;
using System.Linq;
using CommonModels.Entity;

namespace Groove.Services
{
    public class GroupService: IGroupService
    {
        private readonly IAccountsService _accountsService;

        public GroupService(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        public IEnumerable<Group> ListGroups(long? accountId)
        {
            if (accountId.HasValue)
            {
                var account = _accountsService.GetAccount(accountId.Value);
                return account.Groups;
            }
            var accounts = _accountsService.ListAccounts();
            return accounts.SelectMany(a => a.Groups).ToArray();
        }
    }
}

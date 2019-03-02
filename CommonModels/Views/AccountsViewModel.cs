using System.Collections.Generic;
using CommonModels.Entity;

namespace CommonModels.Views
{
    public class AccountsViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}

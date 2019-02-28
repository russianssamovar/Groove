using System.Collections.Generic;

namespace CommonModels.Entity
{
    public class Account
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
        public List<Group> Groups { get; set; }
        public AccountType Type { get; set; }
    }
}

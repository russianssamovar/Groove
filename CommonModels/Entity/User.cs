using System.Collections.Generic;

namespace CommonModels.Entity
{
    public class User
    {
        public User()
        {
            Accounts = new List<Account>();
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}

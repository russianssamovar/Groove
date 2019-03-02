using System.Collections.Generic;

namespace CommonModels.Entity
{
    public class Account
    {
        public Account()
        {
            Groups = new List<Group>();
        }

        public long Id { get; set; }
        public User Owner { get; set; }
        public string SocialUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public string AccessToken { get; set; }
        public List<Group> Groups { get; set; }
        public AccountType Type { get; set; }
    }
}

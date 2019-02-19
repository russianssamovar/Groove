using System.Collections.Generic;

namespace CommonModels
{
    public class Account
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
        public List<Group> Groups { get; set; }
    }
}

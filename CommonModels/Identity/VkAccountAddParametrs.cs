using System.Collections.Generic;
using System.Linq;

namespace CommonModels.Identity
{
    public class VkAccountAddParametrs
    {
        public string Parametrs { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            return Parametrs.Split("&").ToDictionary(pair => pair.Split("=")[0], pair => pair.Split("=")[1]);
        }
    }
}

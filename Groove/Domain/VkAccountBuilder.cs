using System;
using System.Collections.Generic;
using CommonModels.Entity;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using Group = CommonModels.Entity.Group;

namespace Groove.Domain
{
    public class VkAccountBuilder : IAccountBuilder
    {
        private Account _account { get; set; }
        private VkApi _api { get; set; }

        public VkAccountBuilder(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException(nameof(accessToken));
            }
            _api = new VkApi();

            _api.Authorize(new ApiAuthParams
                           {
                               AccessToken = accessToken
                           });

            _account = new Account
                       {
                           AccessToken = accessToken
                       };
        }

        public IAccountBuilder WithMainInformation()
        {
            var info = _api.Account.GetProfileInfo();
            _account.FirstName = info.FirstName;
            _account.LastName = info.LastName;
            return this;
        }

        public IAccountBuilder WithGroups(GroupsGetParams getParams)
        {
            var groups = _api.Groups.Get(getParams);
            _account.Groups = new List<Group>();
            foreach (var group in groups)
            {
                if (!group.IsAdmin)
                {
                    continue;
                }
                _account.Groups.Add(new Group
                                    {
                                        Id = group.Id,
                                        Url = group.Name
                                    });
            }
            return this;
        }

        public Account GetResult()
        {
            return _account;
        }
    }
}
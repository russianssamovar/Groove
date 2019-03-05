using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Entity;
using Groove.Domain;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using Group = CommonModels.Entity.Group;

namespace Groove.Vk.Domain
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

        public IAccountBuilder WithMainInformation(long userId)
        {
            var info = _api.Users.Get(new List<long>{userId}, ProfileFields.Photo100).FirstOrDefault();
            if (info == null)
            {
                throw new InvalidUserIdException();
            }
            _account.FirstName = info.FirstName;
            _account.LastName = info.LastName;
            _account.AvatarUrl = info.Photo100.ToString();
            _account.SocialUserId = userId.ToString();
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
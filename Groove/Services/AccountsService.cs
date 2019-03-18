using System;
using System.Collections.Generic;
using CommonModels.Entity;
using DBRepository.Interfaces;
using Groove.Domain.Context;
using Groove.Vk.Domain;
using Microsoft.AspNetCore.Http;
using VkNet.Model.RequestParams;

namespace Groove.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IIdentityRepository _identityRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsService(IAccountRepository accountRepository, IIdentityRepository identityRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public IEnumerable<Account> ListAccounts()
        {
            var userId = Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name);
            var accounts = _accountRepository.GetAccounts(userId);
            return _accountRepository.UpdateAccounts(userId, UpdateAccountsInfo(accounts));
        }

        public void AddAccount(Dictionary<string, string> addParams, AccountType type)
        {
            var user = _identityRepository.GetUserById(GrooveAppContext.Id);
            if (user == null)
            {
                return;
            }

            switch (type)
            {
                case AccountType.Vk:
                    _accountRepository.Add(user.Id, InitVkAccount(addParams["#access_token"], addParams["user_id"]));
                    break;
            }
        }
        private IEnumerable<Account> UpdateAccountsInfo(IEnumerable<Account> accounts)
        {
            foreach (var acc in accounts)
            {
                switch (acc.Type)
                {
                    case AccountType.Vk:
                       yield return InitVkAccount(acc.AccessToken, acc.SocialUserId);
                        break;
                }
            }
        }

        private Account InitVkAccount(string token, string socialUserId)
        {
          return new VkAccountBuilder(token).WithMainInformation(Convert.ToInt64(socialUserId)).WithGroups(new GroupsGetParams()).GetResult();
        }
    }
}

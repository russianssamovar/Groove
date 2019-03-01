using System;
using System.Collections.Generic;
using CommonModels.Entity;
using DBRepository.Interfaces;
using Groove.Domain;
using Microsoft.AspNetCore.Http;

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
            return  _accountRepository.GetAccounts(Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name));
        }

        public void AddAccount(string token, AccountType type)
        {
            var user = _identityRepository.GetUserById(Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name));
            if (user == null)
            {
                return;
            }

            switch (type)
            {
                case AccountType.Vk:
                    _accountRepository.Add(user.Id, InitVkAccount(token));
                    break;
                default:
                    break;
            }

           
        }

        private Account InitVkAccount(string token)
        {
          return new VkAccountBuilder(token).WithMainInformation().GetResult();
        }
    }
}

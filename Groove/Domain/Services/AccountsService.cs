using System;
using System.Collections.Generic;
using CommonModels.Entity;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace Groove.Domain.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsService(IAccountRepository accountRepository, IIdentityService identityService, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public IEnumerable<Account> ListAccounts()
        {
            return  _accountRepository.GetAccounts(Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name));
        }

        public void AddAccount(string token)
        {
            var user = _identityService.GetUserById(Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name));
            if (user == null)
            {
                return;
            }

            //var api = new VkApi();
    
            //api.Authorize(new ApiAuthParams
            //              {
            //                  AccessToken = "access_token"
            //              });
            //var res = api.Groups.Get(new GroupsGetParams());


            _accountRepository.Add(new Account
            {
                AccessToken = token,
                OwnerId = user.Id
            });
        }
    }

    //public interface IAccountBuilder
    //{
    //    Account Account  { get; set; }
    //    IAccountBuilder WithMainInformation();
    //    IAccountBuilder WithGroups();
    //    Account GetResult();

    //}

    //public class VkAccountBuilder : IAccountBuilder
    //{
    //    private readonly Account _account;

    //    public Account Account => _account;

    //    public IAccountBuilder WithMainInformation()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IAccountBuilder WithGroups()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

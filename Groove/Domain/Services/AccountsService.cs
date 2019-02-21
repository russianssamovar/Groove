using System;
using System.Security.Claims;
using CommonModels;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Groove.Domain.Services
{
    public class AccountsService
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

        public void AddAccount(string token)
        {
            var user = _identityService.GetUserById(Convert.ToInt64(_httpContextAccessor.HttpContext.User.Identity.Name));
            if (user == null)
            {
                return;
            }

            _accountRepository.Add(new Account
            {
                AccessToken = token,
                Owner = user
            });

        }
    }
}

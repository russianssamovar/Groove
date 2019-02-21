using System;
using System.Collections.Generic;
using CommonModels;
using Groove.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Groove.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IIdentityService _identityService;

        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [Authorize]
        [HttpGet("get")]
        public IEnumerable<Account> GetAccounts()
        {
            return _identityService.GetUser(User.Identity.Name).Accounts;
        }

        [Authorize]
        [HttpGet("add")]
        public IEnumerable<Account> AddAccount(string code)
        {
            var user = _identityService.GetUser(User.Identity.Name);
            return user.Accounts;
        }
    }
}

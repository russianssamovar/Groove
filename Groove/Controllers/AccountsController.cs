using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonModels;
using Groove.Services;
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
        [HttpGet("list")]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var user = await _identityService.GetUser(User.Identity.Name);
            return user.Accounts;
        }

        [HttpGet("add")]
        public async Task<IEnumerable<Account>> AddAccount(string code)
        {
            var user = await _identityService.GetUser(User.Identity.Name);
            return user.Accounts;
        }
    }
}

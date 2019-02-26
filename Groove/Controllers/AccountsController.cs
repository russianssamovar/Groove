using System;
using System.Collections.Generic;
using CommonModels.Entity;
using CommonModels.Identity;
using Groove.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Groove.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService ?? throw new ArgumentNullException(nameof(accountsService));
        }

        [Authorize]
        [HttpPost("add")]
        public bool AddAccount([FromBody]AccountAddTokenModel token)
        {
            _accountsService.AddAccount(token.Code);
            return true;
        }
    
        [Authorize]
        [HttpGet("list")]
        public JsonResult ListAccount()
        {
            return Json(new AccountsViewModel { Accounts = _accountsService.ListAccounts() });
        }

        public class AccountsViewModel
        {
            public IEnumerable<Account> Accounts { get; set; }
        }
    }
}

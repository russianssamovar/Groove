using System;
using CommonModels.Entity;
using CommonModels.Identity;
using CommonModels.Views;
using Groove.Services;
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
        public bool AddAccount([FromBody]VkAccountAddParametrs tokenParams)
        {
            _accountsService.AddAccount(tokenParams.ToDictionary(), AccountType.Vk);
            return true;
        }
    
        [Authorize]
        [HttpGet("list")]
        public JsonResult ListAccount()
        {
            return Json(new AccountsViewModel { Accounts = _accountsService.ListAccounts() });
        }
    }
}

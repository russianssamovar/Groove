using System;
using CommonModels.Identity;
using Groove.Services;
using Microsoft.AspNetCore.Mvc;

namespace Groove.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpPost("token")]
        public JsonResult Token([FromBody]AutorizationModel auth)
        {
            return Json(_identityService.Autorize(auth.Login, auth.Password));
        }
    }
}

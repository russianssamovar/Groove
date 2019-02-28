using System;
using CommonModels.Identity;
using Groove.Domain.Services;
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

        [HttpPost("registration")]
        public JsonResult Registration([FromBody]ReistrationModel reg)
        {
            return Json(_identityService.Registration(reg));
        }

        [HttpGet("isValid")]
        public JsonResult IsValid(string token)
        {
            try
            {
                return Json(_identityService.ValidateToken(token));
            }
            catch 
            {
                return Json(false);
            }
        }
    }
}

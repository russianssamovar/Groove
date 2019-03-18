using System;
using CommonModels.Identity;
using Groove.Domain.Context;
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
            var authModel = _identityService.Autorize(auth.Login, auth.Password);
            GrooveAppContext.Id = authModel.UserId;
            return Json(authModel);
        }

        [HttpPost("registration")]
        public JsonResult Registration([FromBody]ReistrationModel reg)
        {
            var authModel = _identityService.Registration(reg);
            GrooveAppContext.Id = authModel.UserId;
            return Json(authModel);
        }

        [HttpGet("isValid")]
        public JsonResult IsValid(string token)
        {
            var authModel = _identityService.ValidateToken(token);
            GrooveAppContext.Id = authModel.UserId;
            return Json(authModel);
        }
    }
}

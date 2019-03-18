using System;
using CommonModels.Views;
using Groove.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Groove.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController: Controller
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        [Authorize]
        [HttpGet("list")]
        public JsonResult ListGroups(long? accountId = null)
        {
            return Json(new GroupsViewModel{ Groups = _groupService.ListGroups(accountId)});
        }
    }
}

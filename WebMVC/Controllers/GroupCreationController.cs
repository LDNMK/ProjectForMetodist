using FaitLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupCreationController : Controller
    {
        private readonly GroupCreationLogic groupLogic;
        // Assign the object in the constructor for dependency injection
        public GroupCreationController(GroupCreationLogic groupLogic)
        {
            this.groupLogic = groupLogic;
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody]string groupName)
        {
            groupLogic.AddGroup(groupName);

            return Ok();
        }

        [HttpPost]
        public IActionResult ActivateExistingGroups([FromBody] string groupsNames)
        {
            groupLogic.ActivateGroups(groupsNames);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = groupLogic.GetGroups();

            return Ok(groups);
        }
    }
}

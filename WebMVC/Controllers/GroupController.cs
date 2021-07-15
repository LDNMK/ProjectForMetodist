using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupLogic groupLogic;

        public GroupController(GroupLogic groupLogic)
        {
            this.groupLogic = groupLogic;
        }

        [HttpGet]
        public IActionResult GetGroups(int course, int? year)
        {
            var groups = groupLogic.GetGroups(course, year);

            return Ok(groups);
        }

        [HttpGet]
        public IActionResult GetDeactivatedGroups()
        {
            var groups = groupLogic.GetDeactivatedGroups();

            return Ok(groups);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromQuery] string groupName)
        {
            groupLogic.AddGroup(groupName);

            return Ok(new { response = "Group was added" });
        }

        [HttpPost]
        public IActionResult ActivateExistingGroups([FromBody] int[] groupsIds)
        {
            groupLogic.ActivateGroups(groupsIds);

            return Ok();
        }
    }
}

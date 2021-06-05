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
        public IActionResult GetListOfGroups(int course, int year)
        {
            var groups = groupLogic.GetGroupsList(course, year);

            return Ok(groups);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody]string groupName)
        {
            var isSuccessfully = groupLogic.AddGroup(groupName);

            if(isSuccessfully)
            {
                return Ok(new { response = "Group was added" });
            }
            else
            {
                return BadRequest(new { response = "Group already existed" });
            }
        }

        [HttpPost]
        public IActionResult ActivateExistingGroups([FromBody] string groupsIds)
        {
            groupLogic.ActivateGroups(groupsIds);

            return Ok();
        }
    }
}

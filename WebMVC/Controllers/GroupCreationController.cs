using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupCreationController : Controller
    {
        private readonly GroupLogic groupLogic;
        // Assign the object in the constructor for dependency injection
        public GroupCreationController(GroupLogic groupLogic)
        {
            this.groupLogic = groupLogic;
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

        [HttpGet]
        public IActionResult GetGroups()
        {
            var groups = groupLogic.GetGroupsList();

            return Ok(groups);
        }
    }
}

using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Helper;
using WebAPI.Helper.ResponseMessageFactory;
using WebAPI.Helper.ValidationResponse.Enum;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupLogic groupLogic;

        public GroupController(IGroupLogic groupLogic)
        {
            this.groupLogic = groupLogic;
        }

        [HttpGet]
        public IActionResult GetGroups(int course, int? year)
        {
            var groups = groupLogic.GetGroups(course, year);

            if (groups.Count == 0)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.GroupsNotFound));
            }

            return Ok(groups);
        }

        //[HttpGet]
        //public IActionResult GetDeactivatedGroups()
        //{
        //    var groups = groupLogic.GetDeactivatedGroups();

        //    return Ok(groups);
        //}

        [HttpPost]
        public IActionResult CreateGroup([FromQuery] string groupName)
        {
            try
            {
                groupLogic.AddGroup(groupName);
            }
            catch (Exception ex)
            {
                return NotFound(ResponseMessageCreator.GetMessage(ErrorEnum.GroupAlreadyExist, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.GroupCreated));
        }

        //[HttpPost]
        //public IActionResult ActivateExistingGroups([FromBody] int[] groupsIds)
        //{
        //    groupLogic.ActivateGroups(groupsIds);

        //    return Ok();
        //}
    }
}

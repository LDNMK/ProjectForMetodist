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
        [HttpPost]
        public IActionResult CreateGroup([FromBody]string groupName)
        {
            var bs = new GroupCreationLogic();
            bs.AddGroup(groupName);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var bs = new GroupCreationLogic();
            var groups = bs.GetGroups();

            return Ok(groups);
        }
    }
}

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
        public IActionResult CreateGroup(string groupName)
        {
            var bs = new GroupCreationLogic();
            bs.AddGroup(groupName);

            return Ok();
        }
    }
}

using FaitLogic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferStudentController : ControllerBase
    {
        private readonly TransferStudentLogic transfLogic;

        public TransferStudentController(TransferStudentLogic transferLogic)
        {
            this.transfLogic = transferLogic;
        }

        [HttpGet]
        public IActionResult GetListOfGroups(int course, int year)
        {
            var groups = transfLogic.GetGroupsList(course, year);

            return Ok(groups);
        }

        //[HttpGet]
        //public IActionResult TransferGroups(int group)
        //{
        //    var groups = transfLogic.GetGroupsList(course, year);

        //    return Ok(groups);
        //}

        [HttpGet]
        public IActionResult TransferStudent(int studentId)
        {
            transfLogic.TransferStudent(studentId);

            return Ok();
        }
    }
}

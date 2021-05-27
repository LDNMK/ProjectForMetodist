using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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

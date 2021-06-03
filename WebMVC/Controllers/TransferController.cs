using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferLogic transfLogic;

        public TransferController(TransferLogic transferLogic)
        {
            this.transfLogic = transferLogic;
        }

        [HttpPatch]
        public IActionResult TransferGroups(int groupId)
        {
            transfLogic.TransferGroup(groupId);

            return Ok();
        }

        [HttpPatch]
        public IActionResult TransferStudent(int studentId, int groupId)
        {
            transfLogic.TransferStudent(studentId, groupId);

            return Ok();
        }
    }
}

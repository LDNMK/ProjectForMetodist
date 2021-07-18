using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransferController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly TransferLogic transfLogic;

        public TransferController(TransferLogic transferLogic, IMapper mapper)
        {
            this.transfLogic = transferLogic;
            this._mapper = mapper;
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

        [HttpGet]
        async public Task<IActionResult> GetStudentsForTransfer([FromQuery] int groupId, [FromQuery] int year)
        {
            var students = _mapper.Map<ICollection<TransferStudentModel>>(await transfLogic.GetStudents(groupId, year));

            return Ok(students);
        }

        [HttpPost]
        async public Task<IActionResult> TransferStudents([FromBody]ICollection<TransferStudentModel> students)
        {
            await transfLogic.TransferStudents(_mapper.Map<ICollection<TransferStudentDTO>>(students));

            return Ok();
        }
    }
}

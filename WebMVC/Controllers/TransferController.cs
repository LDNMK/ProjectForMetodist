using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Helper;
using WebAPI.Helper.ResponseMessageFactory;
using WebAPI.Helper.ValidationResponse.Enum;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransferController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ITransferLogic transfLogic;

        public TransferController(ITransferLogic transferLogic, IMapper mapper)
        {
            this.transfLogic = transferLogic;
            this._mapper = mapper;
        }

        [HttpGet]
        async public Task<IActionResult> GetStudentsForTransfer([FromQuery] int groupId, [FromQuery] int year)
        {
            var students = _mapper.Map<ICollection<TransferStudentModel>>(await transfLogic.GetStudents(groupId, year));
            if (students.Count == 0)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.TransferStudentsNotFound));
            }

            return Ok(students);
        }

        [HttpPost]
        async public Task<IActionResult> TransferStudents([FromBody]ICollection<TransferStudentModel> students)
        {
            try
            {
                await transfLogic.TransferStudents(_mapper.Map<ICollection<TransferStudentDTO>>(students));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.TransferStudentsUpdateFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.TransferStudentsUpdated));
        }
    }
}

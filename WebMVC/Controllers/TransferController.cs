using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Helper;
using WebAPI.Helper.ResponseModel;
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

        //[HttpPatch]
        //public IActionResult TransferGroups(int groupId)
        //{
        //    transfLogic.TransferGroup(groupId);

        //    return Ok();
        //}

        //[HttpPatch]
        //public IActionResult TransferStudent(int studentId, int groupId)
        //{
        //    transfLogic.TransferStudent(studentId, groupId);

        //    return Ok();
        //}

        [HttpGet]
        async public Task<IActionResult> GetStudentsForTransfer([FromQuery] int groupId, [FromQuery] int year)
        {
            var students = _mapper.Map<ICollection<TransferStudentModel>>(await transfLogic.GetStudents(groupId, year));
            if (students.Count == 0)
            {
                return NotFound(new WarningResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.TransferStudentsNotFound)
                });
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
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.TransferStudentsUpdateFailed)
                });
            }
            

            return Ok(new SuccessResponseModel()
            {
                NotificationText = ValidationHelper.GetEnumDescription(SuccessEnum.TransferStudentsUpdated)
            });
        }
    }
}

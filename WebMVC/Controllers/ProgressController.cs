using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Helper.ValidationResponse.Enum;
using WebAPI.Helper.ResponseMessageFactory;
using System;
using WebAPI.Helper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProgressController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IProgressLogic progressLogic;

        public ProgressController(IMapper mapper, IProgressLogic progressLogic)
        {
            this.mapper = mapper;
            this.progressLogic = progressLogic;
        }

        [HttpGet]
        public IActionResult GetProgress(int year, int groupId, int semesterId)
        {
            var progress = new ProgressDTO();

            try
            {
                progress = progressLogic.GetProgress(year, groupId, semesterId);
                
                if (progress.Subjects.Count == 0)
                {
                    return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.ProgressSubjectsNotFound));
                }
                else if (progress.Students.Count == 0)
                {
                    return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.ProgressStudentsNotFound));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.ProgressLoadFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }
            
            return Ok(progress);
        }

        [HttpPost]
        public IActionResult UpdateProgress([FromBody] ICollection<ProgressStudentModel> students)
        {
            try
            {
                var progressStudentsDto = mapper.Map<ICollection<ProgressStudentModel>, ICollection<ProgressStudentDTO>>(students);
                progressLogic.UpdateProgress(progressStudentsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.ProgressUpdateFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.ProgressUpdated));
        }

        [HttpGet]
        public IActionResult GetStudentAverageMark(int studentId)
        {         
            var result = progressLogic.GetStudentAverageMark(studentId);

            return Ok(result);
        }
    }
}

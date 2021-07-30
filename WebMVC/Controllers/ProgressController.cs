using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using FaitLogic.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Helper;
using WebAPI.Helper.ResponseModel;
using WebAPI.Models;

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
                    return NotFound(new WarningResponseModel()
                    {
                        NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.ProgressSubjectsNotFound)
                    });
                } else if (progress.Students.Count == 0)
                {
                    return NotFound(new WarningResponseModel()
                    {
                        NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.ProgressStudentsNotFound)
                    });
                }
            }
            catch
            {
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.ProgressLoadFailed)
                });
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
            catch
            {
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.ProgressUpdateFailed)
                });
            }

            return Ok(new SuccessResponseModel()
            {
                NotificationText = ValidationHelper.GetEnumDescription(SuccessEnum.ProgressUpdated)
            });
        }

        [HttpGet]
        public IActionResult GetStudentAverageMark(int studentId)
        {         
            var result = progressLogic.GetStudentAverageMark(studentId);

            return Ok(result);
        }
    }
}

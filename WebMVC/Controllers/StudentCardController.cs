using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Helper;
using WebAPI.Helper.ResponseModel;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IStudentCardLogic studentInfoLogic;

        public StudentCardController(IMapper mapper, IStudentCardLogic studentInfoLogic)
        {
            this.mapper = mapper;
            this.studentInfoLogic = studentInfoLogic;
        }

        [HttpPost]
        public IActionResult SaveStudentCardInfo([FromBody]StudentCardModel model)
        {
            try
            {
                studentInfoLogic.AddStudentCardInfo(mapper.Map<StudentCardDTO>(model));
            }
            catch
            {
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.StudentCardSaveFailed)
                });
            }

            return Ok(new SuccessResponseModel()
            {
                NotificationText = ValidationHelper.GetEnumDescription(SuccessEnum.StudentCardUpdated)
            });
        }

        [HttpPut]
        public IActionResult UpdateStudentCardInfo([FromQuery]int studentId, [FromBody] StudentCardModel model)
        {
            try
            {
                studentInfoLogic.UpdateStudentCardInfo(studentId, mapper.Map<StudentCardDTO>(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.StudentCardUpdateFailed)
                });
            }

            return Ok(new SuccessResponseModel()
            {
                NotificationText = ValidationHelper.GetEnumDescription(SuccessEnum.StudentCardUpdated)
            });
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery]int groupId, int? year)
        {
            var result = studentInfoLogic.GetStudents(groupId, year);
            if(result.Count == 0)
            {
                return NotFound(new WarningResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.StudentsNotFound)
                });
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ShowStudentInfo(int studentId)
        {
            var result = mapper.Map<StudentCardModel>(studentInfoLogic.GetStudentInfo(studentId));
            if (result == null)
            {
                return NotFound(new WarningResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.StudentNotFound)
                });
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetSpecialities(int degreeId)
        {
            var result = mapper.Map<ICollection<SpecialityModel>>(studentInfoLogic.GetSpecialities(degreeId));

            if (result.Count == 0)
            {
                return NotFound(new WarningResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(WarningEnum.SpecialitiesNotFound)
                });
            }

            return Ok(result);
        }
    }
}

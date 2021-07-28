using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly StudentCardLogic studentInfoLogic;

        public StudentCardController(IMapper mapper, StudentCardLogic studentInfoLogic)
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
                return new JsonResult(ValidationHelper.GetEnumDescription(ErrorEnum.StudentDbUpdateFailed))
                {
                    StatusCode = 400
                };
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStudentCardInfo([FromQuery]int studentId, [FromBody] StudentCardModel model)
        {
            try
            {
                studentInfoLogic.UpdateStudentCardInfo(studentId, mapper.Map<StudentCardDTO>(model));
            }
            catch
            {
                return new JsonResult(ValidationHelper.GetEnumDescription(ErrorEnum.StudentDbUpdateFailed))
                {
                    StatusCode = 400
                };
            }

            return Ok();
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

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetSpecialities(int degreeId)
        {
            var result = mapper.Map<ICollection<SpecialityModel>>(studentInfoLogic.GetSpecialities(degreeId));

            return Ok(result);
        }
    }
}

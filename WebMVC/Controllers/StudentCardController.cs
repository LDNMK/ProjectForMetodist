using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Helper;
using WebAPI.Helper.ResponseMessageFactory;
using WebAPI.Helper.ValidationResponse.Enum;
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
            catch (Exception ex)
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.StudentCardSaveFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.StudentCardUpdated));
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
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.StudentCardUpdateFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.StudentCardUpdated));
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery]int groupId, int? year)
        {
            var result = studentInfoLogic.GetStudents(groupId, year);
            if (result.Count == 0)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.StudentsNotFound));
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ShowStudentInfo(int studentId)
        {
            var result = mapper.Map<StudentCardModel>(studentInfoLogic.GetStudentInfo(studentId));
            if (result == null)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.StudentNotFound));
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetSpecialities(int degreeId)
        {
            var result = mapper.Map<ICollection<SpecialityModel>>(studentInfoLogic.GetSpecialities(degreeId));
            if (result.Count == 0)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.SpecialitiesNotFound));
            }

            return Ok(result);
        }
    }
}

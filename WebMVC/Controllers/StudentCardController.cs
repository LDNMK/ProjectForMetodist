using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            studentInfoLogic.AddStudentCardInfo(mapper.Map<StudentCardDTO>(model));

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateStudentCardInfo([FromQuery]int studentId, [FromBody] StudentCardModel model)
        {
            studentInfoLogic.UpdateStudentCardInfo(studentId, mapper.Map<StudentCardDTO>(model));

            return Ok();
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery]int groupId, int? year)
        {
            var result = studentInfoLogic.GetStudents(groupId, year);

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
            var isOnlyForMasterDegree = degreeId == (int)DegreeEnum.Master;
            var result = mapper.Map<ICollection<SpecialityModel>>(studentInfoLogic.GetSpecialities(isOnlyForMasterDegree));

            return Ok(result);
        }
    }
}

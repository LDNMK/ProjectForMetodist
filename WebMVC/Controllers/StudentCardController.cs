using AutoMapper;
using Fait.LogicObjects.DTO;
using FaitLogic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly StudentInfoLogic studentInfoLogic;
        // Assign the object in the constructor for dependency injection
        public StudentCardController(IMapper mapper, StudentInfoLogic studentInfoLogic)
        {
            _mapper = mapper;
            this.studentInfoLogic = studentInfoLogic;
        }

        [HttpPost]
        public IActionResult SaveStudentCardInfo([FromBody]StudentCardModel model)
        {
            studentInfoLogic.AddStudentCardInfo(_mapper.Map<StudentCardDTO>(model));

            return Ok();
        }


        [HttpGet]
        public IActionResult GetGroups()
        {
            var result = studentInfoLogic.GetListOfGroups();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetListOfStudents([FromQuery]string group)
        {
            var result = studentInfoLogic.GetListOfStudents(group);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ShowStudentInfo(int studentId)
        {
            var result = studentInfoLogic.GetStudentInfo(studentId);

            return Ok(result);
        }
    }
}

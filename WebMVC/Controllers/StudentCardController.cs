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

        // Assign the object in the constructor for dependency injection
        public StudentCardController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SaveStudentCardInfo([FromBody]StudentCardModel model)
        {
            var bs = new StudentInfoLogic();
            bs.AddStudentCardInfo(_mapper.Map<StudentCardDTO>(model));

            return Ok();
        }


        [HttpGet]
        public IActionResult GetGroups()
        {
            var bs = new StudentInfoLogic();
            var result = bs.GetListOfGroups();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetListOfStudents(string group)
        {
            var bs = new StudentInfoLogic();
            var result = bs.GetListOfStudents(group);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ShowStudentInfo(int studentId)
        {
            var bs = new StudentInfoLogic();
            var result = bs.GetStudentInfo(studentId);

            return Ok(result);
        }
    }
}

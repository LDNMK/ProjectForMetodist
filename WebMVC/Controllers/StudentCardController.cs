using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly StudentCardLogic studentInfoLogic;

        public StudentCardController(IMapper mapper, StudentCardLogic studentInfoLogic)
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

        [HttpPut]
        public IActionResult UpdateStudentCardInfo([FromQuery]int studentId, [FromBody] StudentCardModel model)
        {
            studentInfoLogic.UpdateStudentCardInfo(studentId, _mapper.Map<StudentCardDTO>(model));

            return Ok();
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
            var result = _mapper.Map<StudentCardModel>(studentInfoLogic.GetStudentInfo(studentId));

            return Ok(result);
        }
    }
}

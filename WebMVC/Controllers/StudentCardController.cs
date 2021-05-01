using AutoMapper;
using Fait.DTO;
using FaitLogic;
using Microsoft.AspNetCore.Http;
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
            bs.AddStudentInfo(_mapper.Map<StudentCardDTO>(model));

            return Ok();
        }
    }
}

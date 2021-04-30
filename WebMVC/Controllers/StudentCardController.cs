using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        [HttpPost]
        public IActionResult SaveStudentCardInfo(StudentCardModel model)
        {
            return Ok();
        }
    }
}

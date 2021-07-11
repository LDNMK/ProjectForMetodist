using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProgressController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly ProgressLogic progressLogic;

        public ProgressController(IMapper mapper, ProgressLogic progressLogic)
        {
            this.mapper = mapper;
            this.progressLogic = progressLogic;
        }

        [HttpGet]
        public IActionResult GetProgress(int year, int groupId, int semesterId)
        {
            var progress = progressLogic.GetProgress(year, groupId, semesterId);

            return Ok(progress);
        }

        [HttpPost]
        public IActionResult UpdateProgress([FromBody] ICollection<ProgressStudentModel> students)
        {
            var progressStudentsDto = mapper.Map<ICollection<ProgressStudentModel>, ICollection<ProgressStudentDTO>>(students);

            progressLogic.UpdateProgress(progressStudentsDto);

            return Ok();
        }
    }
}

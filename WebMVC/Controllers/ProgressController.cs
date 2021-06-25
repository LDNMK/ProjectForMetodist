using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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

        [HttpPut]
        public IActionResult UpdateProgress([FromBody] ProgressModel progressModel)
        {
            var progressDto = mapper.Map<ProgressModel, ProgressDTO>(progressModel);

            progressLogic.UpdateProgress(progressDto);

            return Ok();
        }
    }
}

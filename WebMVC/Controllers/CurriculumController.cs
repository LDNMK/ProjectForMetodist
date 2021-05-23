using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly CurriculumLogic curriculumLogic;

        private readonly GroupLogic groupLogic;

        public CurriculumController(IMapper mapper, CurriculumLogic curriculumLogic, GroupLogic groupLogic)
        {
            _mapper = mapper;
            this.curriculumLogic = curriculumLogic;
            this.groupLogic = groupLogic;
        }

        [HttpPost]
        public IActionResult AddCurriculum([FromBody] CurriculumModel curriculumModel)
        {
            var yearPlanId = curriculumLogic.AddCurriculum(_mapper.Map<CurriculumDTO>(curriculumModel));

            if (yearPlanId == null)
            {
                return BadRequest();
            }

            groupLogic.SetYearPlan(curriculumModel.Groups, yearPlanId.Value);

            return Ok();
        }

        [HttpGet]
        public IActionResult ShowCurriculum(int yearPlanId)
        {
            var curriculum = _mapper.Map<CurriculumModel>(curriculumLogic.ShowCurriculum(yearPlanId));

            if (curriculum == null)
            {
                return BadRequest();
            }

            return Ok(curriculum);
        }

        [HttpGet]
        public IActionResult GetListOfYearPlans([FromQuery] int course)
        {
            var yearPlans = curriculumLogic.GetYearPlans(course);

            return Ok(yearPlans);
        }
    }
}

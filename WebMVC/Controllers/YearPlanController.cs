using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YearPlanController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly YearPlanLogic yearPlanLogic;
        private readonly GroupLogic groupLogic;

        public YearPlanController(
            IMapper mapper, 
            YearPlanLogic yearPlanLogic, 
            GroupLogic groupLogic)
        {
            _mapper = mapper;
            this.yearPlanLogic = yearPlanLogic;
            this.groupLogic = groupLogic;
        }

        [HttpPost]
        public IActionResult AddYearPlan([FromBody] YearPlanModel yearPlanModel)
        {
            var yearPlanId = yearPlanLogic.AddYearPlan(_mapper.Map<YearPlanDTO>(yearPlanModel));

            if (yearPlanId == null)
            {
                return BadRequest();
            }

            //groupLogic.SetYearPlan(yearPlanModel.GroupIds, yearPlanId.Value);

            return Ok();
        }

        [HttpGet]
        public IActionResult ShowYearPlan(int yearPlanId)
        {
            var yearPlan = _mapper.Map<YearPlanModel>(yearPlanLogic.ShowYearPlan(yearPlanId));

            if (yearPlan == null)
            {
                return BadRequest();
            }

            return Ok(yearPlan);
        }

        [HttpGet]
        public IActionResult GetListOfYearPlans([FromQuery] int course)
        {
            var yearPlans = yearPlanLogic.GetYearPlans(course);

            return Ok(yearPlans);
        }
    }
}

using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helper.ResponseMessageFactory;
using WebAPI.Helper.ValidationResponse.Enum;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YearPlanController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IYearPlanLogic yearPlanLogic;

        public YearPlanController(
            IMapper mapper, 
            IYearPlanLogic yearPlanLogic)
        {
            this.mapper = mapper;
            this.yearPlanLogic = yearPlanLogic;
        }

        [HttpPost]
        public IActionResult AddYearPlan([FromBody] YearPlanModel yearPlanModel)
        {
            try
            {
                yearPlanLogic.AddYearPlan(mapper.Map<YearPlanDTO>(yearPlanModel));
            }
            catch
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.CreateYearPlanFailed));
            }


            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.YearPlanCreated));
        }

        [HttpPut]
        public IActionResult UpdateYearPlan([FromBody] YearPlanModel yearPlanModel, [FromQuery]int yearPlanId)
        {
            try
            {
                yearPlanLogic.UpdateYearPlan(mapper.Map<YearPlanDTO>(yearPlanModel), yearPlanId);
            }
            catch
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.YearPlanUpdateFailed));

            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.YearPlanUpdated));
        }

        [HttpGet]
        public IActionResult ShowYearPlan(int yearPlanId)
        {
            var yearPlan = mapper.Map<YearPlanModel>(yearPlanLogic.ShowYearPlan(yearPlanId));

            if (yearPlan == null)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.YearPlanNotFound));
            }

            return Ok(yearPlan);
        }

        //[HttpGet]
        //public IActionResult GetListOfYearPlans([FromQuery] int course)
        //{
        //    var yearPlans = yearPlanLogic.GetYearPlans(course);

        //    return Ok(yearPlans);
        //}

        [HttpGet]
        public IActionResult GetYearPlanByGroup([FromQuery] int groupId, int year)
        {
            var yearPlanId = yearPlanLogic.GetYearPlanIdByGroup(groupId, year);
            if (!yearPlanId.HasValue)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.YearPlanNotFound));
            }

            var yearPlan = mapper.Map<YearPlanModel>(yearPlanLogic.ShowYearPlan(yearPlanId.Value));
            if (yearPlan == null)
            {
                return NotFound(ResponseMessageCreator.GetMessage(WarningEnum.YearPlanNotFound));
            }

            return Ok(yearPlan);
        }
    }
}

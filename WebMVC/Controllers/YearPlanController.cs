using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YearPlanController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly YearPlanLogic yearPlanLogic;

        public YearPlanController(
            IMapper mapper, 
            YearPlanLogic yearPlanLogic)
        {
            this.mapper = mapper;
            this.yearPlanLogic = yearPlanLogic;
        }

        [HttpPost]
        public IActionResult AddYearPlan([FromBody] YearPlanModel yearPlanModel)
        {
            yearPlanLogic.AddYearPlan(mapper.Map<YearPlanDTO>(yearPlanModel));

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateYearPlan([FromBody] YearPlanModel yearPlanModel, [FromQuery]int yearPlanId)
        {
            yearPlanLogic.UpdateYearPlan(mapper.Map<YearPlanDTO>(yearPlanModel), yearPlanId);

            return Ok();
        }

        [HttpGet]
        public IActionResult ShowYearPlan(int yearPlanId)
        {
            var yearPlan = mapper.Map<YearPlanModel>(yearPlanLogic.ShowYearPlan(yearPlanId));

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

        [HttpGet]
        public IActionResult GetYearPlanByGroup([FromQuery] int groupId, int year)
        {
            var yearPlanId = yearPlanLogic.GetYearPlanIdByGroup(groupId, year);
            if (!yearPlanId.HasValue)
            {
                return new JsonResult(ValidationHelper.GetErrorDescription(ErrorEnum.YearPlanNotExist))
                {
                    StatusCode = 400
                };
            }

            var yearPlan = mapper.Map<YearPlanModel>(yearPlanLogic.ShowYearPlan(yearPlanId.Value));

            if (yearPlan == null)
            {
                return BadRequest();
            }

            return Ok(yearPlan);
        }
    }
}

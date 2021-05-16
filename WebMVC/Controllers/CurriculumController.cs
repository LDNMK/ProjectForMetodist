using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly CurriculumLogic curriculumLogic;

        public CurriculumController(IMapper mapper, CurriculumLogic curriculumLogic)
        {
            _mapper = mapper;
            this.curriculumLogic = curriculumLogic;
        }

        [HttpPost]
        public IActionResult AddCurriculum([FromBody] CurriculumModel curriculumModel)
        {
            curriculumLogic.AddCurruculum(_mapper.Map<CurriculumDTO>(curriculumModel));

            return Ok();
        }
    }
}

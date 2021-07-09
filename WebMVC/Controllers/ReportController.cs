using FaitLogic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportLogic reportLogic;

        public ReportController(ReportLogic reportLogic)
        {
            this.reportLogic = reportLogic;
        }

        [HttpGet]
        public IActionResult CreateReport(int studentId)
        {
            reportLogic.CreateReport(studentId);

            return Ok();
        }
    }
}

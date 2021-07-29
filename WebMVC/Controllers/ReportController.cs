using FaitLogic.Enums;
using FaitLogic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helper;
using WebAPI.Helper.ResponseModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportLogic reportLogic;
        private readonly StudentCardLogic studentLogic;
        private readonly ProgressLogic progressLogic;

        public ReportController(ReportLogic reportLogic, StudentCardLogic studentLogic, ProgressLogic progressLogic)
        {
            this.reportLogic = reportLogic;
            this.studentLogic = studentLogic;
            this.progressLogic = progressLogic;
        }

        [HttpGet]
        public IActionResult CreateReport(int studentId)
        {
            try
            {
                var studentInfo = studentLogic.GetStudentInfo(studentId);
                var studentProgress = progressLogic.GetStudentProgress(studentId);
                reportLogic.CreateReport(studentInfo, studentProgress);
            }
            catch
            {
                return BadRequest(new ErrorResponseModel()
                {
                    NotificationText = ValidationHelper.GetEnumDescription(ErrorEnum.CreateReportFailed)
                });
            }


            return Ok(new SuccessResponseModel()
            {
                NotificationText = ValidationHelper.GetEnumDescription(SuccessEnum.ReportCreated)
            });
        }
    }
}

using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Helper;
using WebAPI.Helper.ResponseMessageFactory;
using WebAPI.Helper.ValidationResponse.Enum;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportLogic reportLogic;
        private readonly IStudentCardLogic studentLogic;
        private readonly IProgressLogic progressLogic;

        public ReportController(IReportLogic reportLogic, IStudentCardLogic studentLogic, IProgressLogic progressLogic)
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
            catch (Exception ex)
            {
                return BadRequest(ResponseMessageCreator.GetMessage(ErrorEnum.CreateReportFailed, ValidationHelper.GetSerializedErrorInfo(ex)));
            }

            return Ok(ResponseMessageCreator.GetMessage(SuccessEnum.ReportCreated));
        }
    }
}

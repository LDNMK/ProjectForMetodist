using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helper;
using WebAPI.Helper.ResponseModel;

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

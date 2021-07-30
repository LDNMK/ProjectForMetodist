using FaitLogic.DTO;
using System.Collections.Generic;

namespace FaitLogic.Logic.ILogic
{
    public interface IReportLogic
    {
        void CreateReport(StudentCardDTO studentInfoDto, ICollection<StudentProgressDTO> studentProgresses);
    }
}
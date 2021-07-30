using FaitLogic.DTO;
using System.Collections.Generic;

namespace FaitLogic.Logic.ILogic
{
    public interface IProgressLogic
    {
        ProgressDTO GetProgress(int year, int groupId, int semesterId);
        ICollection<StudentProgressDTO> GetStudentProgress(int studentId);
        void UpdateProgress(ICollection<ProgressStudentDTO> students);
        decimal GetStudentAverageMark(int studentId);
    }
}
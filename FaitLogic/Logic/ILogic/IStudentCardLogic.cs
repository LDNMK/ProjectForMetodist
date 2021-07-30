using FaitLogic.DTO;
using System.Collections.Generic;

namespace FaitLogic.Logic.ILogic
{
    public interface IStudentCardLogic
    {
        void AddStudentCardInfo(StudentCardDTO studentCard);
        ICollection<SpecialityDTO> GetSpecialities(int degreeId);
        StudentCardDTO GetStudentInfo(int studentId);
        ICollection<StudentNameWithIdDTO> GetStudents(int groupId, int? year);
        void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard);
    }
}
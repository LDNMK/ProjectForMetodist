using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IStudentCardRepository
    {
        int AddStudentCardToDb(StudentsInfo studentsInfo, Student student);

        void UpdateStudentCardInDb(StudentsInfo studentsInfo, Student student);

        ICollection<StudentNameWithId> GetAllStudents(int groupId);

        StudentsInfo GetStudentExtendedInfo(int studentId);

        Student GetStudentMainInfo(int studentId);
    }
}

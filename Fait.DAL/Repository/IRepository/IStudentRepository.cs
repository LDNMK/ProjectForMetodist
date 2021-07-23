using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);

        void UpdateStudent(Student student);

        ICollection<StudentNameWithId> GetAllStudents(int groupId, int? year);

        Student GetStudentMainInfo(int studentId);

        int GetLastStudentId();
    }
}

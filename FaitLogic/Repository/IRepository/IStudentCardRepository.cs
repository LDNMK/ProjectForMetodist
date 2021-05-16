using Fait.DAL;
using Fait.DAL.NotMapped;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Repository.IRepository
{
    interface IStudentCardRepository
    {
        int AddStudentCardToDb(StudentsInfo studentsInfo, Student student);

        void UpdateStudentCardInDb(StudentsInfo studentsInfo, Student student);

        ICollection<StudentNameWithId> GetAllStudents(int groupNumber, byte? groupNameId);

        StudentsInfo GetStudentExtendedInfo(int studentId);

        Student GetStudentMainInfo(int studentId);
    }
}

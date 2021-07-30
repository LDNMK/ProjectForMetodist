using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IStudentInfoRepository
    {
        void AddStudentInfo(StudentInfo studentInfo);

        void UpdateStudentInfo(StudentInfo studentInfo);

        StudentInfo GetStudentInfo(int studentId);
    }
}

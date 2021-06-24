using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IStudentInfoRepository
    {
        void AddStudentInfo(StudentsInfo studentInfo);

        void UpdateStudentInfo(StudentsInfo studentInfo);

        StudentsInfo GetStudentInfo(int studentId);
    }
}

using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class StudentInfoRepository: Repository<StudentInfo>, IStudentInfoRepository
    {
        public StudentInfoRepository(FAITContext context)
        : base(context)
        {
        }

        public void AddStudentInfo(StudentInfo studentInfo)
        {
            base.Add(studentInfo);
        }

        public void UpdateStudentInfo(StudentInfo studentInfo)
        {
            base.Update(studentInfo);
        }

        public StudentInfo GetStudentInfo(int studentId)
        {
            return base.FindById(studentId);
        }
    }
}

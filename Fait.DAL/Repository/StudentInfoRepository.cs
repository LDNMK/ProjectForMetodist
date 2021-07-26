using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class StudentInfoRepository: Repository<StudentsInfo>, IStudentInfoRepository
    {
        public StudentInfoRepository(FAITContext context)
        : base(context)
        {
        }

        public void AddStudentInfo(StudentsInfo studentInfo)
        {
            base.Add(studentInfo);
        }

        public void UpdateStudentInfo(StudentsInfo studentInfo)
        {
            base.Update(studentInfo);
        }

        public StudentsInfo GetStudentInfo(int studentId)
        {
            return base.FindById(studentId);
        }
    }
}

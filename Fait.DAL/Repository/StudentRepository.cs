using Fait.DAL.NotMapped;
using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Fait.DAL.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(FAITContext context)
            : base(context)
        {
        }

        public void AddStudent(Student student)
        {
            base.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            base.Update(student);
        }

        public ICollection<StudentNameWithId> GetAllStudents(int groupId, int year)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@group_id", groupId),
                new SqlParameter("@year", year)
            };

            return dbContext.StudentNameWithIds.FromSqlRaw("SELECT id, full_name " +
                "FROM dbo.return_students_from_group (@group_id, @year)", parameters).ToList();
        }

        public Student GetStudentMainInfo(int studentId)
        {
            return base.FindById(studentId);
        }

        public int GetLastStudentId()
        {
            return dbContext.Students
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault().Id;
        }
    }
}

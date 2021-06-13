using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace FaitLogic.Repository
{
    public class StudentCardRepository : IStudentCardRepository
    {
        private readonly FAITContext dbContext;

        public StudentCardRepository(FAITContext context)
        {
            dbContext = context;
        }

        //TODO: Test it
        public int AddStudentCardToDb(StudentsInfo studentsInfo, Student student)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    dbContext.Students.Add(student);

                    dbContext.StudentsInfos.Add(studentsInfo);
                    dbContext.SaveChanges();

                    scope.Complete();
                }
                catch(Exception e)
                {
                    scope.Dispose();
                }
            }

            return dbContext.Students
                        .OrderByDescending(x => x.Id)
                        .FirstOrDefault().Id;
        }

        //TODO: Add transaction!!
        public void UpdateStudentCardInDb(StudentsInfo studentsInfo, Student student)
        {
            dbContext.Students.Update(student);
            dbContext.StudentsInfos.Update(studentsInfo);
            dbContext.SaveChanges();
        }

        public ICollection<StudentNameWithId> GetAllStudents(int groupId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@group_id", groupId)
            };

            return dbContext.StudentNameWithIds.FromSqlRaw("SELECT id, full_name " +
                "FROM dbo.return_students_from_group (@group_id)", parameters).ToList();
        }

        public StudentsInfo GetStudentExtendedInfo(int studentId)
        {
            var studentInfo = new StudentsInfo();

            studentInfo = dbContext.StudentsInfos
                .Where(x => x.Id == studentId)
                .SingleOrDefault();

            return studentInfo;
        }

        public Student GetStudentMainInfo(int studentId)
        {
            var student = new Student();

            student = dbContext.Students
                .Where(x => x.Id == studentId)
                .SingleOrDefault();

            return student;
        }
    }
}

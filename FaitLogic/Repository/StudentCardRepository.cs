using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Repository
{
    public class StudentCardRepository : IStudentCardRepository
    {
        private readonly FAIT4Context dbContext;

        public StudentCardRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public int AddStudentCardToDb(StudentsInfo studentsInfo, Student student)
        {
            var studentId = 0;

            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            var lastStudent = dbContext.Students.OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastStudent != null)
            {
                studentsInfo.IdNavigation = lastStudent;
            }

            dbContext.StudentsInfos.Add(studentsInfo);
            dbContext.SaveChanges();
            studentId = lastStudent.Id;

            return studentId;
        }

        public void UpdateStudentCardInDb(StudentsInfo studentsInfo, Student student)
        {
            dbContext.Students.Update(student);
            dbContext.StudentsInfos.Update(studentsInfo);
            dbContext.SaveChanges();
        }

        public ICollection<StudentNameWithId> GetAllStudents(int groupNumber, byte? groupNameId)
        {
            var students = new List<StudentNameWithId>();

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@group_number", groupNumber),
                new SqlParameter("@group_name_id", groupNameId)
            };

            students = dbContext.StudentNameWithIds.FromSqlRaw("SELECT id, full_name " +
                "FROM dbo.return_students_from_group (@group_number, @group_name_id)", parameters).ToList();

            return students;
        }

        public StudentsInfo GetStudentExtendedInfo(int studentId)
        {
            var studentInfo = new StudentsInfo();

            studentInfo = dbContext.StudentsInfos.Where(x => x.Id == studentId).SingleOrDefault();

            return studentInfo;
        }

        public Student GetStudentMainInfo(int studentId)
        {
            var student = new Student();

            student = dbContext.Students.Where(x => x.Id == studentId).SingleOrDefault();

            return student;
        }
    }
}

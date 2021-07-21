using Dapper;
using Fait.DAL.NotMapped;
using Fait.DAL.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public ICollection<StudentNameWithId> GetAllStudents(int groupId, int? year)
        {
            if (year.HasValue)
            {
                return dbContext.GroupStudents
                    .AsNoTracking()
                    .Where(x => x.GroupId == groupId && x.GroupYear == year.Value)
                    .Select(x => new StudentNameWithId()
                    {
                        StudentId = x.StudentId,
                        StudentName = string.Format("{0} {1} {2}", x.Student.LastName, x.Student.FirstName, x.Student.Patronymic)
                    })
                    .ToList();
            }

            return dbContext.GroupStudents
                .AsNoTracking()
                .Where(x => x.GroupId == groupId)
                .Select(x => new StudentNameWithId()
                {
                    StudentId = x.StudentId,
                    StudentName = string.Format("{0} {1} {2}", x.Student.LastName, x.Student.FirstName, x.Student.Patronymic)
                })
                .ToList();
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

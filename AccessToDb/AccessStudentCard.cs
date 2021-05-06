using Fait.DAL;
using System.Linq;
using System;

namespace AccessToDb
{
    public class AccessStudentCard
    {
        public void AddStudentCardToDb(StudentsInfo studentsInfo, Student student)
        {
            using (var dbContext = new FAIT4Context())
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                var lastStudent = dbContext.Students.OrderByDescending(x => x.Id).FirstOrDefault();
                if(lastStudent != null)
                {
                    studentsInfo.IdNavigation = lastStudent;
                }
                
                dbContext.StudentsInfos.Add(studentsInfo);
                dbContext.SaveChanges();
            }
        }
    }
}

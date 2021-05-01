using Fait.DAL;
using System;

namespace AccessToDb
{
    public class AccessStudentInfo
    {
        public void AddStudentInfoToDb(StudentsInfo studentsInfo)
        {
            using (var dbContext = new FAIT3Context())
            {
                dbContext.StudentsInfos.Add(studentsInfo);
                dbContext.SaveChanges();
            }
        }
    }
}

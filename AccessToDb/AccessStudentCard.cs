using Fait.DAL;
using System.Linq;
using System;
using System.Collections.Generic;

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

        public ICollection<int> GetAllGroups()
        {
            var groups = new List<int>();
            using (var dbContext = new FAIT4Context())
            {
                //groups = dbContext.Groups.Where(x => x.Actual == true).Select(x => x.GroupNumber+x.GroupName).ToList();
            }

            return groups;
        }
        public int FindGroupNameId(string groupName)
        {
            int groupNameId;
            using (var dbContext = new FAIT4Context())
            {
                groupNameId = dbContext.GroupNames.Where(x => x.NameOfGroup == groupName).Select(x=>x.Id).SingleOrDefault();
            }

            return groupNameId;
        }
        public ICollection<string> GetAllStudents(int groupNumber, int groupNameId)
        {
            var groups = new List<string>();
            using (var dbContext = new FAIT4Context())
            {
                //groups = dbContext.Students.Where(x => x.ActualGroups.)
            }

            return groups;
        }

        public ICollection<string> GetStudentInfo(int studentId)
        {
            var groups = new List<string>();
            using (var dbContext = new FAIT4Context())
            {
                //groups = dbContext.Students.Where(x => x.ActualGroups.)
            }

            return groups;
        }
    }
}

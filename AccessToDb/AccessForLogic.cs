using Fait.DAL;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccessToDb
{
    public class AccessForLogic
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

        public ICollection<string> AddGroupToDb(Group group)
        {
            var groups = new List<string>();
            using (var dbContext = new FAIT4Context())
            {
                dbContext.Groups.Add(group);
                dbContext.SaveChanges();
            }

            return groups;
        }

        public byte? FindGroupName(string groupName)
        {
            var groupNameId = (byte)0;
            using (var dbContext = new FAIT4Context())
            {
                groupNameId = dbContext.GroupNames
                    .SingleOrDefault(x => x.NameOfGroup.Contains(groupName)).Id;
            }

            return groupNameId;
        }

        public byte CreateNewGroupName(GroupName groupName)
        {
            var groupNameId = (byte)0;
            using (var dbContext = new FAIT4Context())
            {
                dbContext.GroupNames.Add(groupName);
                dbContext.SaveChanges();
                groupNameId = dbContext.GroupNames.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            }
            return groupNameId;
        }

        public ICollection<string> GetAllGroups()
        {
            var groups = new List<string>();
            using (var dbContext = new FAIT4Context())
            {
                groups = dbContext.Groups
                    .Include(x => x.GroupName)
                    .Where(x => x.Actual == true)
                    .Select(x => $"{x.GroupName.NameOfGroup}-{x.GroupNumber}")
                    .ToList();
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

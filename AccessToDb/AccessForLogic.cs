using Fait.DAL;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Fait.DAL.NotMapped;

namespace AccessToDb
{
    public class AccessForLogic
    {
        public int AddStudentCardToDb(StudentsInfo studentsInfo, Student student)
        {
            var studentId = 0;
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
                studentId = lastStudent.Id;
            }

            return studentId;
        }

        public void AddGroupToDb(Group group)
        {
            using (var dbContext = new FAIT4Context())
            {
                dbContext.Groups.Add(group);
                dbContext.SaveChanges();
            }
        }

        public byte? FindGroupName(string groupName)
        {
            var groupNameId = (byte?)0;
            using (var dbContext = new FAIT4Context())
            {
                groupNameId = dbContext.GroupNames
                    .SingleOrDefault(x => x.NameOfGroup.Contains(groupName))?.Id;
            }

            return groupNameId;
        }

        public void FindExistingGroupAndMakeActual(int groupNumber, byte? groupNameId)
        {
            using (var dbContext = new FAIT4Context())
            {
                var group = dbContext.Groups.Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber).SingleOrDefault();
                group.Actual = true;
                dbContext.SaveChanges();
            }
        }

        public int GetGroupId(int groupNumber, byte? groupNameId)
        {
            var group = 0;
            using (var dbContext = new FAIT4Context())
            {
                group = dbContext.Groups.Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber).SingleOrDefault().Id;
            }
            return group;
        }

        public void AddActualGroup(ActualGroup actualGroup)
        {
            using (var dbContext = new FAIT4Context())
            {
                dbContext.ActualGroups.Add(actualGroup);
                dbContext.SaveChanges();
            }
        }

        public byte CreateNewGroupName(GroupName groupName)
        {
            using (var dbContext = new FAIT4Context())
            {
                var lastGroupNameId = dbContext.GroupNames.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                groupName.Id = ++lastGroupNameId;
                dbContext.GroupNames.Add(groupName);
                dbContext.SaveChanges();
            }
            return groupName.Id;
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

        public ICollection<StudentNameWithId> GetAllStudents(int groupNumber, byte? groupNameId)
        {
            var students = new List<StudentNameWithId>();
            using (var dbContext = new FAIT4Context())
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@group_number", groupNumber),
                    new SqlParameter("@group_name_id", groupNameId)
                };

                students = dbContext.StudentNameWithIds.FromSqlRaw("SELECT id, full_name " +
                    "FROM dbo.return_students_from_group (@group_number, @group_name_id)", parameters).ToList();
            }

            return students;
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

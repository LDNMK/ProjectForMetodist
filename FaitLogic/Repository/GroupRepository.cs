using Dapper;
using Fait.DAL;
using Fait.DAL.NotMapped;
using System.Configuration;
using FaitLogic.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FaitLogic.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly FAIT4Context dbContext;

        public GroupRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public void AddGroup(Group group)
        {
            dbContext.Groups.Add(group);
            dbContext.SaveChanges();
        }

        public bool CheckIfGroupExist(int groupNumber, int? groupNameId)
        {
            return dbContext.Groups
                .Any(x => x.GroupdPrefixId == groupNameId && x.GroupNumber == groupNumber);
        }

        public Group FindExistingGroup(int groupId)
        {
            return dbContext.Groups
                .Where(x => x.Id == groupId)
                .SingleOrDefault();
        }

        public ICollection<Group> FindGroupsByYearPlan(int yearPlanId)
        {
            return dbContext.Groups
                .Include(x => x.GroupPrefix)
                .Where(x => x.PlanId == yearPlanId)
                .ToList();
        }

        public ICollection<GroupNameWithId> GetGroupsNames(IEnumerable<int> groupIds)
        {
            return dbContext.Groups
                .Where(x => groupIds.Contains(x.Id))
                .Select(x =>
                    new GroupNameWithId
                    {
                        GroupId = x.Id,
                        GroupName = $"{x.GroupPrefix.Name}-{x.GroupNumber}"
                    })
                .ToList();
        }

        // TODO: NEED TO ADD COLUMN COURSE TO HAVE NORMAL CONDITION!
        public ICollection<Group> GetGroups(int course, int year)
        {
            return dbContext.Groups
                .AsNoTracking()
                .Where(x => x.Actual == true 
                       && x.GroupYear == year 
                       && x.Course == course)
                       //&& x.GroupNumber / 10 == course)
                .ToList();
        }

        public void UpdateGroup(Group group)
        {
            dbContext.Groups.Update(group);
            dbContext.SaveChanges();
        }


        //Check!
        public int GetNextGroupOfStudent(int groupId)
        {
            using (IDbConnection db = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString))
            {
                return db.Query<int>("EXEC return_next_group_id_for_student @group_id", new SqlParameter("@group_id", groupId)).FirstOrDefault();
            }
        }

        public int CreateNewGroupName(GroupPrefix groupName)
        {
            dbContext.GroupNames.Add(groupName);
            dbContext.SaveChanges();

            var lastGroupNameId = dbContext.GroupNames
                .OrderByDescending(x => x.Id)
                .FirstOrDefault().Id;

            return lastGroupNameId;
        }

        public int? FindGroupName(string groupName)
        {
            return dbContext.GroupNames
                .SingleOrDefault(x => x.Name == groupName)?.Id;
        }
    }
}

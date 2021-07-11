using Dapper;
using Fait.DAL.NotMapped;
using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(FAITContext context)
            : base(context)
        {
        }

        public void AddGroup(Group group)
        {
            base.Add(group);
        }

        public bool CheckIfGroupExist(int groupNumber, int? groupNameId)
        {
            return dbContext.Groups
                .Any(x => x.GroupPrefixId == groupNameId && x.GroupNumber == groupNumber);
        }

        public Group FindExistingGroup(int groupId)
        {
            return base.FindById(groupId);
            //return dbContext.Groups
            //    .Where(x => x.Id == groupId)
            //    .SingleOrDefault();
        }

        public ICollection<Group> FindGroupsByYearPlan(int yearPlanId)
        {
            return base.Find(x => x.YearPlanGroups.Select(x=> x.YearPlanId).Contains(yearPlanId));
            //return dbContext.Groups
            //    .Include(x => x.GroupPrefix)
            //    .Where(x => x.PlanId == yearPlanId)
            //    .ToList();
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

        public ICollection<Group> GetGroups(int course)
        {
            return Find(x => x.Actual == true
                       && x.Course == course);
            //return dbContext.Groups
            //    .AsNoTracking()
            //    .Where(x => x.Actual == true 
            //           && x.Course == course)
            //    .ToList();
        }

        public ICollection<Group> GetGroups(int course, int year)
        {
            return Find(x => x.Course == course &&
                x.YearPlanGroups.Select(x => x.YearPlan.Year).Contains(year));

            //return dbContext.Groups
            //    .Where(x => x.Plan.Year == year && x.Course == course)
            //    .ToList();
        }

        public void UpdateGroup(Group group)
        {
            base.Update(group);
        }


        // TODO: Check!
        public int GetNextGroupOfStudent(int groupId)
        {
            using (IDbConnection db = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString))
            {
                return db.Query<int>("EXEC return_next_group_id_for_student @group_id", new SqlParameter("@group_id", groupId)).FirstOrDefault();
            }
        }

        public ICollection<Group> GetDeactivatedGroups()
        {
            return base.Find(x => x.Actual == false);
            //return dbContext.Groups
            //     .AsNoTracking()
            //     .Where(x => x.Actual == false)
            //     .ToList();
        }
    }
}

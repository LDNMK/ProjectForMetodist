using Dapper;
using Fait.DAL.Entities.NotMapped;
using Fait.DAL.NotMapped;
using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
        }

        public ICollection<GroupNameWithId> GetGroupNames(IEnumerable<int> groupIds)
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
        }

        public ICollection<Group> GetGroups(int course, int year)
        {
            return Find(x => x.Course == course &&
                x.YearPlanGroups.Select(x => x.YearPlan.Year).Contains(year));
        }

        public ICollection<int> GetGroupIds(int course, int? year)
        {
            return (year.HasValue ? GetGroups(course, year.Value) : GetGroups(course)).Select(x => x.Id).ToList();
        }

        public void UpdateGroup(Group group)
        {
            base.Update(group);
        }

        public int GetNextGroupId(int groupId)
        {
            using (IDbConnection db = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString))
            {
                return db.Query<int>($"EXEC GetNextGroupId {groupId}").FirstOrDefault();
            }
        }

        //public ICollection<Group> GetDeactivatedGroups()
        //{
        //    return base.Find(x => x.Actual == false);
        //}

        async public Task<ICollection<TransferStudent>> GetStudents(int groupId, int year)
        {
            return await dbContext.GroupStudents
                .Where(x =>
                    x.GroupId == groupId &&
                    x.GroupYear == year)
                .Select(x => new TransferStudent()
                {
                    Id = x.StudentId,
                    FirstName = x.Student.FirstName,
                    LastName = x.Student.LastName,
                    Patronymic = x.Student.Patronymic,
                    StateId = x.Student.StudentStateId,
                    IsActive = x.IsActive                   
                })
                .OrderByDescending(x => x.IsActive)
                .ToListAsync();
        }
    }
}

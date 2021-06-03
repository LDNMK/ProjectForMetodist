﻿using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public byte CreateNewGroupName(GroupName groupName)
        {
            dbContext.GroupNames.Add(groupName);
            dbContext.SaveChanges();

            var lastGroupNameId = dbContext.GroupNames
                .OrderByDescending(x => x.Id)
                .FirstOrDefault().Id;

            return lastGroupNameId;
        }

        public bool CheckIfGroupExist(int groupNumber, byte? groupNameId)
        {
            return dbContext.Groups
                .Any(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber);
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
                .Include(x => x.GroupName)
                .Where(x => x.PlanId == yearPlanId)
                .ToList();
        }

        public byte? FindGroupName(string groupName)
        {
            return dbContext.GroupNames
                .SingleOrDefault(x => x.NameOfGroup
                                        .Contains(groupName))?.Id;
        }

        public List<GroupNameWithId> GetGroupsNames(IEnumerable<int> groupIds)
        {
            return dbContext.Groups
                .Where(x => groupIds.Contains(x.Id))
                .Select(x =>
                    new GroupNameWithId
                    {
                        GroupId = x.Id,
                        GroupName = $"{x.GroupName.NameOfGroup}-{x.GroupNumber}"
                    })
                .ToList();
        }

        public ICollection<GroupNameWithId> GetAllGroups()
        {
            return dbContext.Groups
                .Include(x => x.GroupName)
                .Where(x => x.Actual == true)
                .Select(x => new GroupNameWithId { GroupId = x.Id, GroupName = $"{x.GroupName.NameOfGroup}-{x.GroupNumber}" })
                .ToList();
        }

        //Need To Make One option of taking groups!!!
        public List<ICollection<Group>> GetGroups(int course, int year)
        {
            return dbContext.YearPlans
                .Where(x => x.PlanYear == year && x.Course == course)
                .Select(x => x.Groups)
                .ToList();
        }

        public int GetGroupId(int groupNumber, byte? groupNameId)
        {
            return dbContext.Groups
                .Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber)
                .SingleOrDefault().Id;
        }

        public void UpdateGroup(Group group)
        {
            dbContext.Groups.Update(group);
            dbContext.SaveChanges();
        }

        public GroupId GetNextGroupOfStudent(int groupId)
        {
            return dbContext.GroupIds.FromSqlRaw("EXEC return_next_group_id_for_student @group_id", new SqlParameter("@group_id", groupId)).AsEnumerable().FirstOrDefault();
        }
    }
}

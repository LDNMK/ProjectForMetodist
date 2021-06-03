using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.Repository.IRepository;
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
            byte lastGroupNameId;

            dbContext.GroupNames.Add(groupName);
            dbContext.SaveChanges();

            lastGroupNameId = dbContext.GroupNames.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            return lastGroupNameId;
        }

        public bool CheckIfGroupExist(int groupNumber, byte? groupNameId)
        {
            return dbContext.Groups.Any(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber);
        }

        public Group FindExistingGroup(int groupId)
        {
            var group = new Group();

            group = dbContext.Groups.Where(x => x.Id == groupId).SingleOrDefault();

            return group;
        }

        public byte? FindGroupName(string groupName)
        {
            var groupNameId = (byte?)0;

            groupNameId = dbContext.GroupNames
                .SingleOrDefault(x => x.NameOfGroup.Contains(groupName))?.Id;

            return groupNameId;
        }

        public ICollection<GroupNameWithId> GetAllGroups()
        {
            return dbContext.Groups
                .Include(x => x.GroupName)
                .Where(x => x.Actual == true)
                .Select(x => new GroupNameWithId { GroupId = x.Id, GroupName = $"{x.GroupName.NameOfGroup}-{x.GroupNumber}" })
                .ToList();
        }

        public int GetGroupId(int groupNumber, byte? groupNameId)
        {
            var group = 0;

            group = dbContext.Groups.Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber).SingleOrDefault().Id;

            return group;
        }

        public void UpdateGroup(Group group)
        {
            dbContext.Groups.Update(group);
            dbContext.SaveChanges();
        }
    }
}

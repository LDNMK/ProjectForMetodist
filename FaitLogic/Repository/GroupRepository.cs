using Fait.DAL;
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

        public void AddActualGroup(ActualGroup actualGroup)
        {
            dbContext.ActualGroups.Add(actualGroup);
            dbContext.SaveChanges();
        }

        public void AddGroupToDb(Group group)
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

        public Group FindExistingGroup(int groupNumber, byte? groupNameId)
        {
            var group = new Group();

            group = dbContext.Groups.Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber).SingleOrDefault();

            return group;
        }

        public byte? FindGroupName(string groupName)
        {
            var groupNameId = (byte?)0;

            groupNameId = dbContext.GroupNames
                .SingleOrDefault(x => x.NameOfGroup.Contains(groupName))?.Id;

            return groupNameId;
        }

        public ICollection<string> GetAllGroups()
        {
            var groups = new List<string>();

            groups = dbContext.Groups
                .Include(x => x.GroupName)
                .Where(x => x.Actual == true)
                .Select(x => $"{x.GroupName.NameOfGroup}-{x.GroupNumber}")
                .ToList();

            return groups;
        }

        public int GetGroupId(int groupNumber, byte? groupNameId)
        {
            var group = 0;

            group = dbContext.Groups.Where(x => x.GroupNameId == groupNameId && x.GroupNumber == groupNumber).SingleOrDefault().Id;

            return group;
        }

        public void MakeGroupActive(Group group)
        {
            group.Actual = true;
            dbContext.SaveChanges();
        }
    }
}

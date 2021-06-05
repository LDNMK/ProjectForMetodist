using Fait.DAL;
using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace FaitLogic.Repository.IRepository
{
    public interface IGroupRepository
    {
        void AddGroup(Group group);

        bool CheckIfGroupExist(int groupNumber, byte? groupNameId);

        byte? FindGroupName(string groupName);

        Group FindExistingGroup(int groupId);

        ICollection<Group> FindGroupsByYearPlan(int yearPlanId);

        ICollection<GroupNameWithId> GetGroupsNames(IEnumerable<int> groupIds);

        int GetNextGroupOfStudent(int groupId);

        void UpdateGroup(Group group);

        byte CreateNewGroupName(GroupName groupName);

        ICollection<Group> GetGroups(int course, int year);
    }
}

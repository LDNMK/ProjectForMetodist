using Fait.DAL;
using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace FaitLogic.Repository.IRepository
{
    interface IGroupRepository
    {
        void AddGroup(Group group);

        byte? FindGroupName(string groupName);

        Group FindExistingGroup(int groupId);

        void UpdateGroup(Group group);

        int GetGroupId(int groupNumber, byte? groupNameId);

        byte CreateNewGroupName(GroupName groupName);

        ICollection<GroupNameWithId> GetAllGroups();
    }
}

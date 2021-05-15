using Fait.DAL;
using System.Collections.Generic;

namespace FaitLogic.Repository.IRepository
{
    interface IGroupRepository
    {
        void AddGroupToDb(Group group);

        byte? FindGroupName(string groupName);

        Group FindExistingGroup(int groupNumber, byte? groupNameId);

        void MakeGroupActive(Group group);

        int GetGroupId(int groupNumber, byte? groupNameId);

        void AddActualGroup(ActualGroup actualGroup);

        byte CreateNewGroupName(GroupName groupName);

        ICollection<string> GetAllGroups();
    }
}

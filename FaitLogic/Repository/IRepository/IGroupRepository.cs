using Fait.DAL;
using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace FaitLogic.Repository.IRepository
{
    interface IGroupRepository
    {
        void AddGroup(Group group);

        void UpdateActualGroup(ActualGroup group);

        ActualGroup FindActualStudentGroup(int studentId);

        byte? FindGroupName(string groupName);

        Group FindExistingGroup(int groupId);

        void UpdateGroup(Group group);

        int GetGroupId(int groupNumber, byte? groupNameId);

        void AddActualGroup(ActualGroup actualGroup);

        byte CreateNewGroupName(GroupName groupName);

        ICollection<GroupNameWithId> GetAllGroups();
    }
}

﻿using Fait.DAL.NotMapped;
using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IGroupRepository
    {
        void AddGroup(Group group);

        bool CheckIfGroupExist(int groupNumber, int? groupNameId);

        Group FindExistingGroup(int groupId);

        ICollection<Group> FindGroupsByYearPlan(int yearPlanId);

        ICollection<GroupNameWithId> GetGroupsNames(IEnumerable<int> groupIds);

        int GetNextGroupOfStudent(int groupId);

        void UpdateGroup(Group group);

        ICollection<Group> GetGroups(int course, int year);

        ICollection<Group> GetGroups(int course);

        ICollection<Group> GetDeactivatedGroups();
    }
}

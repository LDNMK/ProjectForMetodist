﻿using Fait.DAL;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;

namespace FaitLogic.Logic
{
    public class GroupLogic
    {
        private readonly GroupRepository groupRepo;

        public GroupLogic(GroupRepository groupRepository)
        {
            groupRepo = groupRepository;
        }

        public bool AddGroup(string groupName)
        {
            var parts = groupName.Split('-');
            var newGroupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = groupRepo.FindGroupName(newGroupName);
            if(groupNameId == null)
            {
                groupNameId = groupRepo.CreateNewGroupName(new GroupName { NameOfGroup = newGroupName });
            }

            var findedGroup = groupRepo.FindExistingGroup(groupNumber, groupNameId);

            if(findedGroup != null)
            {
                return false;
            }

            var newGroup = new Group
            {
                GroupNumber = groupNumber,
                GroupNameId = groupNameId,
                Actual = true,
                GroupYear = 2021
            };

            groupRepo.AddGroupToDb(newGroup);

            return true;
        }

        public void ActivateGroups(string groupsNames)
        {
            var groupsNamesArray = groupsNames.Split('\n');
            foreach (var group in groupsNamesArray)
            {
                if (group.Length < 1)
                { 
                    return; 
                }

                var partsOfName = group.Split('-');

                var existingGroupName = partsOfName[0];
                var groupNumber = Convert.ToInt32(partsOfName[1]);

                var groupNameId = groupRepo.FindGroupName(existingGroupName);

                var findedGroup = groupRepo.FindExistingGroup(groupNumber, groupNameId);
                findedGroup.Actual = true;

                groupRepo.UpdateGroup(findedGroup);
            }
        }

        public ICollection<string> GetGroupsList()
        {
            return groupRepo.GetAllGroups();
        }

        public void SetYearPlan(string groupsNames, int yearPlanId)
        {
            var groupsNamesArray = groupsNames.Split('\n');
            foreach (var group in groupsNamesArray)
            {
                if (group.Length < 1)
                {
                    return;
                }

                var partsOfName = group.Split('-');

                var existingGroupName = partsOfName[0];
                var groupNumber = Convert.ToInt32(partsOfName[1]);

                var groupNameId = groupRepo.FindGroupName(existingGroupName);

                var findedGroup = groupRepo.FindExistingGroup(groupNumber, groupNameId);
                findedGroup.PlanId = yearPlanId;

                groupRepo.UpdateGroup(findedGroup);
            }
        }
    }
}

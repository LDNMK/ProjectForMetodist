using AccessToDb;
using Fait.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic
{
    public class GroupCreationLogic
    {
        private AccessForLogic accessGroup { get; set; } = new AccessForLogic();

        public bool AddGroup(string groupName)
        {
            var parts = groupName.Split(new[] { '-', '_', ' ' });
            var newGroupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = accessGroup.FindGroupName(newGroupName);
            if(groupNameId == null)
            {
                groupNameId = accessGroup.CreateNewGroupName(new GroupName { NameOfGroup = newGroupName });
            }

            var findedGroup = accessGroup.FindExistingGroup(groupNumber, groupNameId);

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

            accessGroup.AddGroupToDb(newGroup);

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

                var partsOfName = group.Split(new[] { '-', '_', ' ' });

                var existingGroupName = partsOfName[0];
                var groupNumber = Convert.ToInt32(partsOfName[1]);

                var groupNameId = accessGroup.FindGroupName(existingGroupName);

                var findedGroup = accessGroup.FindExistingGroup(groupNumber, groupNameId);
                accessGroup.MakeGroupActive(findedGroup);
            }
        }

        public ICollection<string> GetGroups()
        {
            return accessGroup.GetAllGroups();
        }
    }
}

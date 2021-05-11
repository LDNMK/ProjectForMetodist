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
        public void AddGroup(string groupName)
        {
            var parts = groupName.Split(new[] { '-', '_', ' ' });
            var newGroupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = accessGroup.FindGroupName(newGroupName);
            if(groupNameId == null)
            {
                groupNameId = accessGroup.CreateNewGroupName(new GroupName { NameOfGroup = newGroupName });
            }

            var newGroup = new Group
            {
                GroupNumber = groupNumber,
                GroupNameId = groupNameId,
                Actual = true,
                GroupYear = 2021
            };

            accessGroup.AddGroupToDb(newGroup);
        }

        public ICollection<string> GetGroups()
        {
            return accessGroup.GetAllGroups();
        }
    }
}

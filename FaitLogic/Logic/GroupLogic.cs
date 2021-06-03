using AutoMapper;
using Fait.DAL;
using Fait.DAL.NotMapped;
using FaitLogic.DTO;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class GroupLogic
    {
        private readonly IMapper mapper;

        private readonly GroupRepository groupRepo;

        public GroupLogic(IMapper mapper, GroupRepository groupRepository)
        {
            this.mapper = mapper;
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

            var isExisted = groupRepo.CheckIfGroupExist(groupNumber, groupNameId);

            if(isExisted)
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

            groupRepo.AddGroup(newGroup);

            return true;
        }

        public void ActivateGroups(string groupsIds)
        {
            var groupsIdsArray = groupsIds.Split(',');
            foreach (var groupId in groupsIdsArray)
            {
                if (groupId.Length < 1)
                { 
                    return; 
                }

                var findedGroup = groupRepo.FindExistingGroup(Convert.ToInt32(groupId));
                findedGroup.Actual = true;

                groupRepo.UpdateGroup(findedGroup);
            }
        }

        public ICollection<GroupNameWithIdDTO> GetGroupsList()
        {
            return mapper.Map<ICollection<GroupNameWithIdDTO>>(groupRepo.GetAllGroups());
        }

        public void SetYearPlan(string groupsIds, int yearPlanId)
        {
            var groupsIdsArray = groupsIds.Split(',');
            foreach (var groupId in groupsIdsArray)
            {
                if (groupId.Length < 1)
                {
                    return;
                }

                var findedGroup = groupRepo.FindExistingGroup(Convert.ToInt32(groupId));
                findedGroup.PlanId = yearPlanId;

                groupRepo.UpdateGroup(findedGroup);
            }
        }
    }
}

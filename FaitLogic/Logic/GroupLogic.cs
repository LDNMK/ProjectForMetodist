using AutoMapper;
using Fait.DAL;
using FaitLogic.DTO;
using FaitLogic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class GroupLogic
    {
        private readonly IMapper mapper;

        private readonly IGroupRepository groupRepo;

        public GroupLogic(IMapper mapper, IGroupRepository groupRepository)
        {
            this.mapper = mapper;
            groupRepo = groupRepository;
        }

        public void AddGroup(string groupName)
        {
            var parts = groupName.Split('-');
            var newGroupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = groupRepo.FindGroupName(newGroupName);
            if(groupNameId == null)
            {
                groupNameId = groupRepo.CreateNewGroupName(new GroupPrefix { Name = newGroupName });
            }

            var isExisted = groupRepo.CheckIfGroupExist(groupNumber, groupNameId);

            if(isExisted)
            {
                throw new Exception();
            }

            var newGroup = new Group
            {
                GroupNumber = groupNumber,
                GroupdPrefixId = groupNameId,
                Actual = true,
                GroupYear = 2021,
                Course = groupNumber / 10
            };

            groupRepo.AddGroup(newGroup);
        }

        public ICollection<GroupNameWithIdDTO> GetGroupsList(int course, int? year)
        {
            ICollection<Group> groups;

            if (year.HasValue)
            {
                groups = groupRepo.GetGroups(course, year.Value);
            }
            else
            {
                groups = groupRepo.GetGroups(course);
            }

            var groupIds = groups.Select(X => X.Id);
            var groupNames = mapper.Map<ICollection<GroupNameWithIdDTO>>(groupRepo.GetGroupsNames(groupIds));

            return groupNames;
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

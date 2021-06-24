using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class GroupLogic
    {
        private readonly IMapper mapper;

        private readonly UnitOfWork unitOfWork;

        public GroupLogic
        (
            IMapper mapper,
            UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void AddGroup(string groupName)
        {
            var parts = groupName.Split('-');
            var newGroupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = unitOfWork.GroupPrefixRepository.FindGroupName(newGroupName);
            if (groupNameId == null)
            {
                unitOfWork.GroupPrefixRepository.CreateNewGroupName(new GroupPrefix { Name = newGroupName });
                unitOfWork.Save();
                groupNameId = unitOfWork.GroupPrefixRepository.GetLastGroupPrefixId();
            }

            var isExisted = unitOfWork.GroupRepository.CheckIfGroupExist(groupNumber, groupNameId);

            if (isExisted)
            {
                throw new Exception();
            }

            var newGroup = new Group
            {
                GroupNumber = groupNumber,
                GroupPrefixId = groupNameId,
                Actual = true,
                Course = groupNumber / 10
            };

            unitOfWork.GroupRepository.AddGroup(newGroup);
            unitOfWork.Save();
        }

        public ICollection<GroupNameWithIdDTO> GetGroupsList(int course, int? year)
        {
            //ICollection<Group> groups;

            //if (year.HasValue)
            //{
            //    groups = groupRepo.GetGroups(course, year.Value);
            //}
            //else
            //{
            //    groups = groupRepo.GetGroups(course);
            //}

            var groups = year.HasValue ? unitOfWork.GroupRepository.GetGroups(course, year.Value) : unitOfWork.GroupRepository.GetGroups(course);

            var groupIds = groups.Select(X => X.Id);
            var groupNames = mapper.Map<ICollection<GroupNameWithIdDTO>>(unitOfWork.GroupRepository.GetGroupsNames(groupIds));

            return groupNames;
        }

        public ICollection<GroupNameWithIdDTO> GetDeactivatedGroups()
        {
            var groups = unitOfWork.GroupRepository.GetDeactivatedGroups();

            var groupIds = groups.Select(X => X.Id);
            var groupNames = mapper.Map<ICollection<GroupNameWithIdDTO>>(unitOfWork.GroupRepository.GetGroupsNames(groupIds));

            return groupNames;
        }

        public void ActivateGroups(int[] groupsIds)
        {
            foreach (var groupId in groupsIds)
            {
                var group = unitOfWork.GroupRepository.FindExistingGroup(groupId);
                group.Actual = true;

                unitOfWork.GroupRepository.UpdateGroup(group);
                unitOfWork.Save();
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

                var findedGroup = unitOfWork.GroupRepository.FindExistingGroup(Convert.ToInt32(groupId));
                findedGroup.PlanId = yearPlanId;

                unitOfWork.GroupRepository.UpdateGroup(findedGroup);
                unitOfWork.Save();
            }
        }
    }
}

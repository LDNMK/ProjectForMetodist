using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using FaitLogic.Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IMapper mapper;

        private readonly IUnitOfWork unitOfWork;

        public GroupLogic
        (
            IMapper mapper,
            IUnitOfWork unitOfWork)
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
                GroupPrefixId = groupNameId.Value,
                Actual = true,
                Course = groupNumber / 10
            };

            unitOfWork.GroupRepository.AddGroup(newGroup);
            unitOfWork.Save();
        }

        public ICollection<GroupNameWithIdDTO> GetGroups(int course, int? year)
        {
            var groupIds = unitOfWork.GroupRepository.GetGroupIds(course, year);
            var groupNames = mapper.Map<ICollection<GroupNameWithIdDTO>>(unitOfWork.GroupRepository.GetGroupNames(groupIds));

            return groupNames;
        }

        //public ICollection<GroupNameWithIdDTO> GetDeactivatedGroups()
        //{
        //    var groups = unitOfWork.GroupRepository.GetDeactivatedGroups();

        //    var groupIds = groups.Select(X => X.Id);
        //    var groupNames = mapper.Map<ICollection<GroupNameWithIdDTO>>(unitOfWork.GroupRepository.GetGroupNames(groupIds));

        //    return groupNames;
        //}

        //public void ActivateGroups(int[] groupsIds)
        //{
        //    foreach (var groupId in groupsIds)
        //    {
        //        var group = unitOfWork.GroupRepository.FindExistingGroup(groupId);
        //        group.Actual = true;

        //        unitOfWork.GroupRepository.UpdateGroup(group);
        //    }
        //    unitOfWork.Save();
        //}
    }
}

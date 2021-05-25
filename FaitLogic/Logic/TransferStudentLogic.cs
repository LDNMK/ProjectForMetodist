using AutoMapper;
using FaitLogic.DTO;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaitLogic.Logic
{
    public class TransferStudentLogic
    {
        private readonly TransferStudentRepository transferRepo;

        private readonly IMapper mapper;

        public TransferStudentLogic(IMapper mapper, TransferStudentRepository curriculumRepository)
        {
            this.mapper = mapper;
            transferRepo = curriculumRepository;
        }

        public ICollection<GroupWithIdDTO> GetGroupsList(int course, int year)
        {
            var groups = transferRepo.GetGroups(course, year);

            var groupNames = new List<GroupWithIdDTO>();
            foreach (var groupsOfYearPlan in groups)
            {
                var groupsIds = groupsOfYearPlan.Select(x => x.Id);
                groupNames.AddRange(transferRepo.GetGroupsNames(groupsIds));
            }

            return groupNames;
        }

        public void TransferStudent(int studentId)
        {
            transferRepo.TransferStudentToNextGroup(studentId);
        }
    }
}

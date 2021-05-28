using AutoMapper;
using Fait.DAL;
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

        private readonly GroupRepository groupRepo;

        private readonly StudentCardRepository studentRepo;

        private readonly IMapper mapper;

        public TransferStudentLogic(IMapper mapper, TransferStudentRepository curriculumRepository, GroupRepository groupRepository, StudentCardRepository studentRepository)
        {
            this.mapper = mapper;
            transferRepo = curriculumRepository;
            groupRepo = groupRepository;
            studentRepo = studentRepository;
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
            var nextGroupId = transferRepo.GetNextGroupOfStudent(studentId);

            if(nextGroupId == null)
            {
                throw new Exception();
            }

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = nextGroupId.Id
            };

            groupRepo.AddActualGroup(actualGroup);
        }

        public void TransferGroup(string group)
        {
            var partOfGroup = group.Split(new[] { '-', '_', ' ' });
            var groupNumber = Convert.ToInt32(partOfGroup[1]);
            var groupName = partOfGroup[0];
            var groupNameId = groupRepo.FindGroupName(groupName);

            var listOfStudents = studentRepo.GetAllStudents(groupNumber, groupNameId);

            if (listOfStudents == null)
            {
                throw new Exception();
            }

            var nextGroupId = transferRepo.GetNextGroupOfStudent(listOfStudents.First().StudentId);

            if (nextGroupId == null)
            {
                throw new Exception();
            }

            var actualGroups = new List<ActualGroup>();
            foreach (var student in listOfStudents)
            {
                actualGroups.Add(new ActualGroup
                {
                    StudentId = student.StudentId,
                    GroupId = nextGroupId.Id
                });
            }

            groupRepo.AddActualGroups(actualGroups);
        }
    }
}

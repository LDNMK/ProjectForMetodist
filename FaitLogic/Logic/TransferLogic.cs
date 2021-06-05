using AutoMapper;
using Fait.DAL;
using FaitLogic.Repository.IRepository;
using System;
using System.Collections.Generic;

namespace FaitLogic.Logic
{
    public class TransferLogic
    {
        private readonly IMapper mapper;

        private readonly IGroupRepository groupRepo;
        private readonly IStudentCardRepository studentRepo;
        private readonly IActualGroupRepository actualGroupRepo;

        public TransferLogic(
            IMapper mapper,
            IGroupRepository groupRepository,
            IStudentCardRepository studentRepository,
            IActualGroupRepository actualGroupRepository)
        {
            this.mapper = mapper;
            groupRepo = groupRepository;
            studentRepo = studentRepository;
            actualGroupRepo = actualGroupRepository;
        }

        public void TransferStudent(int studentId, int groupId)
        {
            var nextGroupId = groupRepo.GetNextGroupOfStudent(groupId);

            if(nextGroupId == default)
            {
                throw new Exception();
            }

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = nextGroupId
            };

            actualGroupRepo.AddActualGroup(actualGroup);
        }

        public void TransferGroup(int groupId)
        {
            var nextGroupId = groupRepo.GetNextGroupOfStudent(groupId);
            if (nextGroupId == default)
            {
                throw new Exception();
            }

            var listOfStudents = studentRepo.GetAllStudents(groupId);
            if (listOfStudents == null)
            {
                throw new Exception();
            }

            var actualGroups = new List<ActualGroup>();
            foreach (var student in listOfStudents)
            {
                actualGroups.Add(new ActualGroup
                {
                    StudentId = student.StudentId,
                    GroupId = nextGroupId
                });
            }
            actualGroupRepo.AddActualGroups(actualGroups);

            var grou = groupRepo.FindExistingGroup(groupId);
            grou.Actual = false;
            groupRepo.UpdateGroup(grou);
        }
    }
}

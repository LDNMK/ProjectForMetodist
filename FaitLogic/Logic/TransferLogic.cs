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
    public class TransferLogic
    {
        private readonly IMapper mapper;

        private readonly GroupRepository groupRepo;
        private readonly StudentCardRepository studentRepo;
        private readonly ActualGroupRepository actualGroupRepo;

        public TransferLogic(
            IMapper mapper, 
            GroupRepository groupRepository, 
            StudentCardRepository studentRepository, 
            ActualGroupRepository actualGroupRepository)
        {
            this.mapper = mapper;
            groupRepo = groupRepository;
            studentRepo = studentRepository;
            actualGroupRepo = actualGroupRepository;
        }

        public void TransferStudent(int studentId, int groupId)
        {
            var nextGroupId = groupRepo.GetNextGroupOfStudent(groupId);

            if(nextGroupId == null)
            {
                throw new Exception();
            }

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = nextGroupId.Id
            };

            actualGroupRepo.AddActualGroup(actualGroup);
        }

        public void TransferGroup(int groupId)
        {
            var nextGroupId = groupRepo.GetNextGroupOfStudent(groupId);
            if (nextGroupId == null)
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
                    GroupId = nextGroupId.Id
                });
            }
            actualGroupRepo.AddActualGroups(actualGroups);

            var grou = groupRepo.FindExistingGroup(groupId);
            grou.Actual = false;
            groupRepo.UpdateGroup(grou);
        }
    }
}

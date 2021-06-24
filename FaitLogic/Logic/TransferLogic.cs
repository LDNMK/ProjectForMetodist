using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using System;
using System.Collections.Generic;

namespace FaitLogic.Logic
{
    public class TransferLogic
    {
        private readonly IMapper mapper;

        private readonly UnitOfWork unitOfWork;

        public TransferLogic(
            IMapper mapper,
            UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void TransferStudent(int studentId, int groupId)
        {
            var nextGroupId = unitOfWork.GroupRepository.GetNextGroupOfStudent(groupId);

            if(nextGroupId == default)
            {
                throw new Exception();
            }

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = nextGroupId
            };

            unitOfWork.ActualGroupRepository.AddActualGroup(actualGroup);
            unitOfWork.Save();
        }

        public void TransferGroup(int groupId)
        {
            var nextGroupId = unitOfWork.GroupRepository.GetNextGroupOfStudent(groupId);
            if (nextGroupId == default)
            {
                throw new Exception();
            }

            var listOfStudents = unitOfWork.StudentRepository.GetAllStudents(groupId);
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
            unitOfWork.ActualGroupRepository.AddActualGroups(actualGroups);

            var grou = unitOfWork.GroupRepository.FindExistingGroup(groupId);
            grou.Actual = false;
            unitOfWork.GroupRepository.UpdateGroup(grou);
            unitOfWork.Save();
        }
    }
}

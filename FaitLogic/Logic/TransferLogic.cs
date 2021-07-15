using AutoMapper;
using Fait.DAL;
using Fait.DAL.Entities.NotMapped;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaitLogic.Logic
{
    public class TransferLogic
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;

        public TransferLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void TransferStudent(int studentId, int groupId)
        {
            var nextGroupId = unitOfWork.GroupRepository.GetNextGroupOfStudent(groupId);

            if(nextGroupId == default)
            {
                throw new Exception();
            }

            var actualGroup = new GroupStudent
            {
                StudentId = studentId,
                GroupId = nextGroupId
            };

            unitOfWork.GroupStudentRepository.AddGroupStudent(actualGroup);
            unitOfWork.Save();
        }

        public void TransferGroup(int groupId)
        {
            var nextGroupId = unitOfWork.GroupRepository.GetNextGroupOfStudent(groupId);
            if (nextGroupId == default)
            {
                throw new Exception();
            }

            // REDO!

            //var listOfStudents = unitOfWork.StudentRepository.GetAllStudents(groupId, year);
            //if (listOfStudents == null)
            //{
            //    throw new Exception();
            //}

            //var actualGroups = new List<ActualGroup>();
            //foreach (var student in listOfStudents)
            //{
            //    actualGroups.Add(new ActualGroup
            //    {
            //        StudentId = student.StudentId,
            //        GroupId = nextGroupId
            //    });
            //}
            //unitOfWork.ActualGroupRepository.AddActualGroups(actualGroups);

            //var grou = unitOfWork.GroupRepository.FindExistingGroup(groupId);
            //grou.Actual = false;
            //unitOfWork.GroupRepository.UpdateGroup(grou);
            //unitOfWork.Save();
        }

        async public Task<ICollection<TransferStudentDTO>> GetStudents(int groupId, int year)
        {
            var students = await unitOfWork.GroupRepository.GetStudents(groupId, year);

            var r =  _mapper.Map<ICollection<TransferStudent>, ICollection<TransferStudentDTO>>(students);

            return r;
        }
    }
}

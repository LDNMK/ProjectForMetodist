using AutoMapper;
using Fait.DAL;
using Fait.DAL.Entities.NotMapped;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaitLogic.Logic
{
    public class TransferLogic : ITransferLogic
    {
        private readonly IMapper mapper;

        private readonly IUnitOfWork unitOfWork;

        public TransferLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ICollection<TransferStudentDTO>> GetStudents(int groupId, int year)
        {
            var students = await unitOfWork.GroupRepository.GetStudents(groupId, year);
            return mapper.Map<ICollection<TransferStudent>, ICollection<TransferStudentDTO>>(students);
        }

        // TODO: check do we need async/await here?
        public async Task TransferStudents(ICollection<TransferStudentDTO> students)
        {
            foreach (var student in students)
            {
                var studentTransferHistory = new StudentTransferHistory()
                {
                    StudentId = student.Id,
                    StateId = student.StateId,
                    OperationDate = DateTime.Now.Date
                };

                if (student.StateId == (int)StudentStateEnum.DefaultTransfer)
                {
                    var currentGroup = unitOfWork.GroupStudentRepository.FindStudentActualGroup(student.Id);
                    var nextGroupId = unitOfWork.GroupRepository.GetNextGroupId(student.GroupId.Value);
                    var group = unitOfWork.GroupRepository.FindExistingGroup(student.GroupId.Value);

                    var groupStudent = new GroupStudent
                    {
                        GroupId = nextGroupId,
                        StudentId = student.Id,
                        GroupYear = currentGroup.GroupYear + 1,
                        IsActive = true
                    };
                    unitOfWork.GroupStudentRepository.AddGroupStudent(groupStudent);
                    currentGroup.IsActive = false;

                    studentTransferHistory.FromCourse = (byte)group.Course;
                    studentTransferHistory.ToCourse = (byte)(group.Course + 1);

                    unitOfWork.StudentTransferHistoryRepository.AddTransferHistory(studentTransferHistory);
                }
                else
                {
                    var studentInfo = unitOfWork.StudentRepository.GetStudentMainInfo(student.Id);
                    studentInfo.StudentStateId = student.StateId;
                    unitOfWork.StudentRepository.UpdateStudent(studentInfo);
                }
            }

            unitOfWork.Save();
        }
    }
}

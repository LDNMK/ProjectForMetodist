using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class StudentCardLogic : IStudentCardLogic
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;

        public StudentCardLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void AddStudentCardInfo(StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentInfo>(studentCard);
            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);

            unitOfWork.BeginTransaction();
            try
            {
                unitOfWork.StudentRepository.AddStudent(student);
                unitOfWork.StudentInfoRepository.AddStudentInfo(studentInfo);
                unitOfWork.Save();
            }
            catch (DbUpdateException e)
            {
                unitOfWork.RevertTransaction();
                throw;
            }
            unitOfWork.CommitTransaction();

            var studentId = unitOfWork.StudentRepository.GetLastStudentId();

            var actualGroup = new GroupStudent
            {
                StudentId = studentId,
                GroupId = studentCard.GroupId,
                GroupYear = studentCard.GroupYear,
                IsActive = true
            };

            unitOfWork.GroupStudentRepository.AddGroupStudent(actualGroup);
            unitOfWork.Save();
        }

        public void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentInfo>(studentCard);

            studentInfo.Id = studentId;

            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);
            student.Id = studentId;

            var transferHistoriesDb = unitOfWork.StudentTransferHistoryRepository.GetStudentTransferHistory(studentId);
            var transferHistories = _mapper.Map<ICollection<StudentTransferHistoryDTO>, ICollection<StudentTransferHistory>>(studentCard.TransferHistory);

            foreach (var thDb in transferHistoriesDb)
            {
                var transferHistoryCurrent = transferHistories.First(x => x.Id == thDb.Id);
                thDb.OrderDate = transferHistoryCurrent.OrderDate;
                thDb.OrderNumber = transferHistoryCurrent.OrderNumber;
                thDb.Content = transferHistoryCurrent.Content;
            }

            unitOfWork.BeginTransaction();
            try
            {
                unitOfWork.StudentRepository.UpdateStudent(student);
                unitOfWork.StudentInfoRepository.UpdateStudentInfo(studentInfo);
                unitOfWork.StudentTransferHistoryRepository.UpdateStudentTransferHistories(transferHistoriesDb);
                unitOfWork.Save();
            }
            catch (DbUpdateException e)
            {
                unitOfWork.RevertTransaction();
                throw;
            }
            unitOfWork.CommitTransaction();
        }

        public ICollection<StudentNameWithIdDTO> GetStudents(int groupId, int? year)
        {
            var listOfStudents = _mapper.Map<ICollection<StudentNameWithIdDTO>>(unitOfWork.StudentRepository.GetAllStudents(groupId, year));

            return listOfStudents;
        }

        public StudentCardDTO GetStudentInfo(int studentId)
        {
            var studentInfo = unitOfWork.StudentInfoRepository.GetStudentInfo(studentId);
            var studentFullInfo = _mapper.Map<StudentInfo, StudentCardDTO>(studentInfo);

            var student = unitOfWork.StudentRepository.GetStudentMainInfo(studentId);

            studentFullInfo.LastName = student.LastName;
            studentFullInfo.FirstName = student.FirstName;
            studentFullInfo.Patronymic = student.Patronymic;
            studentFullInfo.StudentStateId = student.StudentStateId;
            studentFullInfo.SpecialityId = student.SpecialityId.GetValueOrDefault();

            studentFullInfo.TransferHistory = _mapper.Map<ICollection<StudentTransferHistoryDTO>>(unitOfWork.StudentTransferHistoryRepository.GetStudentTransferHistory(studentId));

            return studentFullInfo;
        }

        public ICollection<SpecialityDTO> GetSpecialities(int degreeId)
        {
            var isOnlyForMasterDegree = degreeId == (int)DegreeEnum.Master;
            var specialities = unitOfWork.SpecialityRepository.GetSpecialities(isOnlyForMasterDegree);
            return _mapper.Map<ICollection<Speciality>, ICollection<SpecialityDTO>>(specialities);
        }
    }
}

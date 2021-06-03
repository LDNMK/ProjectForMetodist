using AutoMapper;
using Fait.DAL;
using FaitLogic.DTO;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;

namespace FaitLogic.Logic
{
    public class StudentCardLogic
    {
        private readonly IMapper _mapper;

        private readonly StudentCardRepository studentCardRepo;
        private readonly ActualGroupRepository actualGroupRepo;

        public StudentCardLogic(
            IMapper mapper, 
            StudentCardRepository studentCardRepository, 
            ActualGroupRepository actualGroupRepository)
        {
            _mapper = mapper;
            studentCardRepo = studentCardRepository;
            actualGroupRepo = actualGroupRepository;
        }

        public void AddStudentCardInfo(StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            //SpecialityId = studentCard.!!!!
            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);

            var studentId = studentCardRepo.AddStudentCardToDb(studentInfo, student);

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = studentCard.GroupId
            };

            actualGroupRepo.AddActualGroup(actualGroup);
        }

        public void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Id = studentId;
            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            //SpecialityId = studentCard.!!!!
            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);
            student.Id = studentId;

            studentCardRepo.UpdateStudentCardInDb(studentInfo, student);
        }

        public ICollection<StudentNameWithIdDTO> GetListOfStudents(int groupId)
        {
            var listOfStudents = _mapper.Map<ICollection<StudentNameWithIdDTO>>(studentCardRepo.GetAllStudents(groupId));

            return listOfStudents;
        }

        public StudentCardDTO GetStudentInfo(int studentId)
        {
            var studentInfo = studentCardRepo.GetStudentExtendedInfo(studentId);
            var studentFullInfo = _mapper.Map<StudentsInfo, StudentCardDTO>(studentInfo);

            studentFullInfo.Birthday = studentInfo.Birthdate.ToString("yyyy-MM-dd");
            studentFullInfo.EmploymentGivenDate = studentInfo.EmploymentGivenDate.Value.ToString("yyyy-MM-dd");

            var student = studentCardRepo.GetStudentMainInfo(studentId);

            studentFullInfo.LastName = student.LastName;
            studentFullInfo.FirstName = student.FirstName;
            studentFullInfo.Patronymic = student.Patronymic;
            studentFullInfo.StudentStateId = student.StudentStateId;

            return studentFullInfo;
        }
    }
}

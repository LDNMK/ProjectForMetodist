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

        private readonly GroupRepository groupRepo;

        public StudentCardLogic(IMapper mapper, StudentCardRepository studentCardRepository, GroupRepository groupRepository)
        {
            _mapper = mapper;
            studentCardRepo = studentCardRepository;
            groupRepo = groupRepository;
        }

        public void AddStudentCardInfo(StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            //SpecialityId = studentCard.!!!!
            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);

            var studentId = studentCardRepo.AddStudentCardToDb(studentInfo, student);

            var groupId = GetGroupIdByGroupName(studentCard.Group);

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = groupId
            };

            groupRepo.AddActualGroup(actualGroup);
        }

        public void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            //SpecialityId = studentCard.!!!!
            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);

            studentCardRepo.UpdateStudentCardInDb(studentInfo, student);

            var groupId = GetGroupIdByGroupName(studentCard.Group);

            var actualStudentGroup = groupRepo.FindActualStudentGroup(studentId);
            actualStudentGroup.GroupId = groupId;

            groupRepo.UpdateActualGroup(actualStudentGroup);
        }

        public ICollection<StudentNameWithIdDTO> GetListOfStudents(string group)
        {
            var partOfGroup = group.Split('-');
            var groupNumber = Convert.ToInt32(partOfGroup[1]);
            var groupName = partOfGroup[0];
            var groupNameId = groupRepo.FindGroupName(groupName);

            var listOfStudents = _mapper.Map<ICollection<StudentNameWithIdDTO>>(studentCardRepo.GetAllStudents(groupNumber, groupNameId));

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

        public int GetGroupIdByGroupName(string groupName)
        {
            var parts = groupName.Split('-');
            var groupAbbreviation = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = groupRepo.FindGroupName(groupAbbreviation);
            return groupRepo.GetGroupId(groupNumber, groupNameId);
        }
    }
}

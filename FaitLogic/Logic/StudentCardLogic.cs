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
            var studentInfo = new StudentsInfo
            {
                Birthdate = Convert.ToDateTime(studentCard.Birthday),
                BirthPlace = studentCard.BirthPlace,
                Immenseness = studentCard.Immenseness,
                MaritalStatusId = studentCard.MaritalStatusId,
                Registration = studentCard.Registration,
                Exemption = studentCard.Exemption,
                ExpirienceCompetitionId = studentCard.ExpirienceCompetitionId,
                TransferFrom = studentCard.TransferFrom,
                TransferDirection = studentCard.TransferDirection,
                CompetitionConditions = studentCard.CompetitionConditions,
                OutOfCompetitionInfo = studentCard.OutOfCompetitionInfo,
                AmmendsId = studentCard.AmmendsId,
                EmploymentNumber = studentCard.EmploymentNumber,
                EmploymentAuthority = studentCard.EmploymentAuthority,
                EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate),
                RegistrOrPassportNumber = studentCard.RegistrOrPassportNumber
            };
            var student = new Student
            {
                //SpecialityId = studentCard.
                FirstName = studentCard.Name,
                LastName = studentCard.Surname,
                Patronymic = studentCard.Patronymic,
                StudentState = studentCard.StudStateId
            };

            var studentId = studentCardRepo.AddStudentCardToDb(studentInfo, student);

            var parts = studentCard.Group.Split(new[] { '-', '_', ' ' });
            var groupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = groupRepo.FindGroupName(groupName);
            var groupId = groupRepo.GetGroupId(groupNumber, groupNameId);

            var actualGroup = new ActualGroup
            {
                StudentId = studentId,
                GroupId = groupId
            };

            groupRepo.AddActualGroup(actualGroup);
        }

        public void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard)
        {
            var studentInfo = new StudentsInfo
            {
                Id = studentId,
                Birthdate = Convert.ToDateTime(studentCard.Birthday),
                BirthPlace = studentCard.BirthPlace,
                Immenseness = studentCard.Immenseness,
                MaritalStatusId = studentCard.MaritalStatusId,
                Registration = studentCard.Registration,
                Exemption = studentCard.Exemption,
                ExpirienceCompetitionId = studentCard.ExpirienceCompetitionId,
                TransferFrom = studentCard.TransferFrom,
                TransferDirection = studentCard.TransferDirection,
                CompetitionConditions = studentCard.CompetitionConditions,
                OutOfCompetitionInfo = studentCard.OutOfCompetitionInfo,
                AmmendsId = studentCard.AmmendsId,
                EmploymentNumber = studentCard.EmploymentNumber,
                EmploymentAuthority = studentCard.EmploymentAuthority,
                EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate),
                RegistrOrPassportNumber = studentCard.RegistrOrPassportNumber
            };
            var student = new Student
            {
                Id = studentId,
                //SpecialityId = studentCard.
                FirstName = studentCard.Name,
                LastName = studentCard.Surname,
                Patronymic = studentCard.Patronymic,
                StudentState = studentCard.StudStateId
            };

            studentCardRepo.UpdateStudentCardInDb(studentInfo, student);

            var parts = studentCard.Group.Split(new[] { '-', '_', ' ' });
            var groupName = parts[0];
            var groupNumber = Convert.ToInt32(parts[1]);

            var groupNameId = groupRepo.FindGroupName(groupName);
            var groupId = groupRepo.GetGroupId(groupNumber, groupNameId);

            var actualStudentGroup = groupRepo.FindActualStudentGroup(studentId);
            actualStudentGroup.GroupId = groupId;

            groupRepo.UpdateActualGroup(actualStudentGroup);
        }

        public ICollection<StudentNameWithIdDTO> GetListOfStudents(string group)
        {
            var partOfGroup = group.Split(new[] { '-', '_', ' ' });
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

            studentFullInfo.Surname = student.LastName;
            studentFullInfo.Name = student.FirstName;
            studentFullInfo.Patronymic = student.Patronymic;
            studentFullInfo.StudStateId = student.StudentState;

            return studentFullInfo;
        }
    }
}

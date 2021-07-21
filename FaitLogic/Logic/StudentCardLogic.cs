using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaitLogic.Logic
{
    public class StudentCardLogic
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
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);

            unitOfWork.StudentRepository.AddStudent(student);
            unitOfWork.StudentInfoRepository.AddStudentInfo(studentInfo);
            unitOfWork.Save();

            var studentId = unitOfWork.StudentRepository.GetLastStudentId();

            var actualGroup = new GroupStudent
            {
                StudentId = studentId,
                GroupId = studentCard.GroupId,
                GroupYear = studentCard.GroupYear
            };

            unitOfWork.GroupStudentRepository.AddGroupStudent(actualGroup);
            unitOfWork.Save();
        }

        public void UpdateStudentCardInfo(int studentId, StudentCardDTO studentCard)
        {
            var studentInfo = _mapper.Map<StudentCardDTO, StudentsInfo>(studentCard);

            studentInfo.Id = studentId;
            studentInfo.Birthdate = Convert.ToDateTime(studentCard.Birthday);
            studentInfo.EmploymentGivenDate = Convert.ToDateTime(studentCard.EmploymentGivenDate);

            var student = _mapper.Map<StudentCardDTO, Student>(studentCard);
            student.Id = studentId;

            unitOfWork.StudentRepository.UpdateStudent(student);
            unitOfWork.StudentInfoRepository.UpdateStudentInfo(studentInfo);
            unitOfWork.Save();
        }

        public ICollection<StudentNameWithIdDTO> GetStudents(int groupId, int? year)
        {
            var listOfStudents = _mapper.Map<ICollection<StudentNameWithIdDTO>>(unitOfWork.StudentRepository.GetAllStudents(groupId, year));

            return listOfStudents;
        }

        public StudentCardDTO GetStudentInfo(int studentId)
        {
            var studentInfo = unitOfWork.StudentInfoRepository.GetStudentInfo(studentId);
            var studentFullInfo = _mapper.Map<StudentsInfo, StudentCardDTO>(studentInfo);

            studentFullInfo.Birthday = studentInfo.Birthdate.ToString("yyyy-MM-dd");
            studentFullInfo.EmploymentGivenDate = studentInfo.EmploymentGivenDate.Value.ToString("yyyy-MM-dd");

            var student = unitOfWork.StudentRepository.GetStudentMainInfo(studentId);

            studentFullInfo.LastName = student.LastName;
            studentFullInfo.FirstName = student.FirstName;
            studentFullInfo.Patronymic = student.Patronymic;
            studentFullInfo.StudentStateId = student.StudentStateId;
            studentFullInfo.SpecialityId = student.SpecialityId;

            return studentFullInfo;
        }

        public ICollection<SpecialityDTO> GetSpecialities(bool isOnlyForMasterDegree)
        {
            var specialities = unitOfWork.SpecialityRepository.GetSpecialities(isOnlyForMasterDegree);
            return _mapper.Map<ICollection<Speciality>, ICollection<SpecialityDTO>>(specialities);
        }
    }
}

using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Logic.ILogic;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class ProgressLogic : IProgressLogic
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;

        public ProgressLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ProgressDTO GetProgress(int year, int groupId, int semesterId)
        {
            var yearPlan = unitOfWork.YearPlanRepository.GetYearPlanByGroup(groupId, year);
            var subjects = unitOfWork.SubjectRepository.FindSubjects(yearPlan.Id);

            var subjectsDto = new List<ProgressSubjectDTO>();
            foreach (var subject in subjects)
            {
                var subjectSemester = unitOfWork.SubjectSemesterRepository
                    .FindSubjectSemesters(subject.Id)
                    .FirstOrDefault(x => x.SemesterId == semesterId);

                if (subjectSemester != null)
                {
                    subjectsDto.Add(new ProgressSubjectDTO
                    {
                         Id = subjectSemester.Id,
                         Name = subject.Name,
                         IsCourseWorkExist = subjectSemester.IndividualTaskType == (int)TaskEnum.CourseWork 
                    });
                }
            }

            var subjectIds = subjectsDto.Select(x => x.Id).ToList();
            var subjectMarks = unitOfWork.ProgressRepository.FindMarksBySubject(subjectIds);

            // Not sure
            var students = unitOfWork.StudentRepository.GetAllStudents(groupId, year);

            var studentDto = new List<ProgressStudentDTO>();
            foreach (var student in students)
            {
                var studentWithMarks = new ProgressStudentDTO
                {
                    Id = student.StudentId,
                    Name = student.StudentName
                };

                var studentMarks = new List<SubjectStudentMarkDTO>();
                foreach (var mark in subjectMarks.Where(x => x.StudentId == student.StudentId))
                {
                    studentMarks.Add(new SubjectStudentMarkDTO
                    {
                        Id = mark.SubjectId,
                        Mark = mark.SubjectMark,
                        TaskMark = mark.TaskMark.GetValueOrDefault(),
                        ModifiedOn = mark.ModifiedOn
                    });
                }
                studentWithMarks.Subjects = studentMarks;

                studentDto.Add(studentWithMarks);
            }

            var progressDto = new ProgressDTO
            {
                Students = studentDto,
                Subjects = subjectsDto
            };

            return progressDto;
        }

        public void UpdateProgress(ICollection<ProgressStudentDTO> students)
        {
            foreach (var student in students)
            {
                foreach (var subject in student.Subjects)
                {
                    var mark = unitOfWork.ProgressRepository.FindMark(subject.Id, student.Id);

                    if (mark != null && subject.Mark != null)
                    {
                        mark.SubjectMark = subject.Mark;
                        mark.ModifiedOn = subject.ModifiedOn;
                        mark.TaskMark = subject.TaskMark;
                        unitOfWork.ProgressRepository.UpdateMark(mark);
                    }
                    else if (mark != null && subject.Mark == null)
                    {
                        // TODO: Change db column to nullable and int
                        unitOfWork.ProgressRepository.DeleteMark(mark);
                    }
                    else if (mark == null && subject.Mark != null)
                    {
                        mark = new Mark
                        {
                            StudentId = student.Id,
                            SubjectId = subject.Id,
                            SubjectMark = subject.Mark,
                            TaskMark = subject.TaskMark,
                            ModifiedOn = subject.ModifiedOn
                        };

                        unitOfWork.ProgressRepository.AddMark(mark);
                    }

                    //TODO: can we make it outside loop?
                    unitOfWork.Save();
                }
            }
        }

        public decimal GetStudentAverageMark(int studentId)
        {            
            var studentMarks =  unitOfWork.ProgressRepository.GetStudentMarks(studentId);
            if(studentMarks.Count != 0)
                return studentMarks.Sum() / (decimal)studentMarks.Count;
            return 0;
        }

        public ICollection<StudentProgressDTO> GetStudentProgress(int studentId)
        {
            var studentGroups = unitOfWork.GroupStudentRepository.GetStudentGroups(studentId);
            var studentProgresses = new List<StudentProgressDTO>();
            foreach (var studentGroup in studentGroups)
            {
                var studentProgress = new StudentProgressDTO();
                studentProgress.Course = studentGroup.Course;
                var yearPlan = unitOfWork.YearPlanRepository.GetYearPlanByGroup(studentGroup.GroupId, studentGroup.Year);
                if(yearPlan == null)
                {
                    continue;
                }

                var subjects = unitOfWork.SubjectRepository.FindSubjects(yearPlan.Id);

                var subjectsDto = new List<StudentSubjectDTO>();
                foreach (var subject in subjects)
                {
                    var studentSubject = _mapper.Map<StudentSubjectDTO>(subject);

                    var subjectSemesters = unitOfWork.SubjectSemesterRepository
                        .FindSubjectSemesters(subject.Id);

                    foreach (var subjectSemester in subjectSemesters)
                    {
                        var semester = subjectSemester.SemesterId;
                        var subjectMark = unitOfWork.ProgressRepository.FindMark(subjectSemester.Id, studentId);
                        if(subjectMark == null)
                        {
                            continue;
                        }

                        var taskExist = subjectSemester.IndividualTaskType == (int)TaskEnum.CourseWork;
                        studentSubject.SubjectSemesters.Add(
                            new StudentSubjectSemesterDTO()
                            {
                                SemesterId = semester,
                                Mark = taskExist ?
                                    (subjectMark.SubjectMark.GetValueOrDefault() + subjectMark.TaskMark.GetValueOrDefault()) / 2
                                    : subjectMark.SubjectMark.GetValueOrDefault(),
                                ModifiedOn = subjectMark.ModifiedOn.GetValueOrDefault()
                            });
                    }

                    subjectsDto.Add(studentSubject);
                }

                studentProgress.Subjects = subjectsDto;
                studentProgresses.Add(studentProgress);
            }

            return studentProgresses;
        }
    }
}

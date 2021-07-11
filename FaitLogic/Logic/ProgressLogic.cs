using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaitLogic.Logic
{
    public class ProgressLogic
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
                    .FirstOrDefault(x => x.Semester == semesterId);

                if (subjectSemester != null)
                {
                    subjectsDto.Add(new ProgressSubjectDTO
                    {
                         Id = subjectSemester.Id,
                         Name = subject.Name
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
                        Mark = mark.SubjectMark //(mark.SubjectMark + mark.TaskMark) / 2
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
                        mark.SubjectMark = (byte)subject.Mark.Value;
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
                            SubjectMark = (byte)subject.Mark.Value
                        };

                        unitOfWork.ProgressRepository.AddMark(mark);
                    }

                    unitOfWork.Save();
                }
            }
        }
    }
}

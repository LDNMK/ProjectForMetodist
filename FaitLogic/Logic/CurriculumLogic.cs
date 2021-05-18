using Fait.DAL;
using FaitLogic.DTO;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Logic
{
    public class CurriculumLogic
    {
        private readonly CurriculumRepository curriculumRepo;

        public CurriculumLogic(CurriculumRepository curriculumRepository)
        {
            curriculumRepo = curriculumRepository;
        }

        public void AddCurriculum(CurriculumDTO curriculumInfo)
        {
            var yearPlan = new YearPlan
            {
                PlanName = curriculumInfo.PlanName,
                Course = (byte)curriculumInfo.Course
            };

            var yearPlanId = curriculumRepo.AddYearPlan(yearPlan);

            foreach (var subject in curriculumInfo.SubjectInfo)
            {
                AddSubjects(subject, yearPlanId);
            }
        }

        private void AddSubjects(SubjectDTO subjectDto, int? yearPlanId)
        {
            var parts = subjectDto.SubHoursAndETCS.Split(new[] { '\\', '/' });
            var subHours = Convert.ToInt32(parts[0]);
            var ects = Convert.ToInt32(parts[1]);

            var subjectInfo = new SubjectInfo
            {
                PlanId = yearPlanId,
                SubName = subjectDto.SubName,
                SubHours = subHours,
                Ects = ects,
                Faculty = subjectDto.Faculty
            };

            var subjectInfoId = curriculumRepo.AddSubjectInfo(subjectInfo);

            if (subjectDto.SpringMonitoring != null && subjectDto.SpringTask != null)
            {
                var springSubject = new Subject
                {
                    SubjectInfoId = subjectInfoId.Value,
                    Monitoring = subjectDto.SpringMonitoring.Value,
                    Task = subjectDto.SpringTask.Value,
                    Semester = true
                };
                curriculumRepo.AddSubject(springSubject);
            }

            if (subjectDto.AutumnMonitoring != null && subjectDto.AutumnTask != null)
            {
                var autumnSubject = new Subject
                {
                    SubjectInfoId = subjectInfoId.Value,
                    Monitoring = subjectDto.AutumnMonitoring.Value,
                    Task = subjectDto.AutumnTask.Value,
                    Semester = false
                };
                curriculumRepo.AddSubject(autumnSubject);
            }
        }
    }
}

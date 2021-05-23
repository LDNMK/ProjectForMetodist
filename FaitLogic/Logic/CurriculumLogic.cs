using AutoMapper;
using Fait.DAL;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaitLogic.Logic
{
    public class CurriculumLogic
    {
        private readonly CurriculumRepository curriculumRepo;

        private readonly IMapper mapper;

        public CurriculumLogic(IMapper mapper,CurriculumRepository curriculumRepository)
        {
            this.mapper = mapper;
            curriculumRepo = curriculumRepository;
        }

        public CurriculumDTO ShowCurriculum(int yearPlanId)
        {
            var yearPlan = curriculumRepo.FindYearPlan(yearPlanId);

            var groupsNames = curriculumRepo.FindGroupsByYearPlan(yearPlanId).Select(x =>x.GroupName.NameOfGroup);
            var curriculum = new CurriculumDTO
            {
                PlanName = yearPlan.PlanName,
                Course = yearPlan.Course,
                Groups = string.Join(',', groupsNames)
            };

            var subjects = curriculumRepo.FindSubjectsInfo(yearPlanId);

            var subjectsDto = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                var subj = new SubjectDTO
                {
                    SubName = subject.SubName,
                    SubHoursAndETCS = string.Format($"{subject.SubHours}/{subject.Ects}"),
                    Faculty = subject.Faculty
                };

                var sb = curriculumRepo.FindSubjects(subject.Id);

                var autumn = sb.Find(x => x.Semester == (int)SemesterEnum.Autumn);
                if (autumn!= null)
                {
                    subj.AutumnMonitoring = autumn.Monitoring;
                    subj.AutumnTask = autumn.Task;
                }

                var spring = sb.Find(x => x.Semester == (int)SemesterEnum.Spring);
                if (spring != null)
                {
                    subj.SpringMonitoring = spring.Monitoring;
                    subj.SpringTask = spring.Task;
                }
                subjectsDto.Add(subj);
            }

            curriculum.SubjectInfo = subjectsDto;

            return curriculum;
        }

        public int? AddCurriculum(CurriculumDTO curriculumInfo)
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

            return yearPlanId;
        }

        public ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course)
        {
            var list = curriculumRepo.GetListOfYearPlans(course);
            var yearPlans = mapper.Map<List<YearPlan>, List<YearPlanNameWithIdDTO>>(curriculumRepo.GetListOfYearPlans(course));

            return yearPlans;
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

            if (subjectDto.SpringMonitoring != (int)MonitoringEnum.SemesterNotExist && subjectDto.SpringTask != (int)TaskEnum.SemesterNotExist)
            {
                var springSubject = new Subject
                {
                    SubjectInfoId = subjectInfoId.Value,
                    Monitoring = subjectDto.SpringMonitoring,
                    Task = subjectDto.SpringTask,
                    Semester = (int)SemesterEnum.Spring
                };
                curriculumRepo.AddSubject(springSubject);
            }

            if (subjectDto.AutumnMonitoring != (int)MonitoringEnum.SemesterNotExist && subjectDto.AutumnTask != (int)TaskEnum.SemesterNotExist)
            {
                var autumnSubject = new Subject
                {
                    SubjectInfoId = subjectInfoId.Value,
                    Monitoring = subjectDto.AutumnMonitoring,
                    Task = subjectDto.AutumnTask,
                    Semester = (int)SemesterEnum.Autumn
                };
                curriculumRepo.AddSubject(autumnSubject);
            }
        }
    }
}

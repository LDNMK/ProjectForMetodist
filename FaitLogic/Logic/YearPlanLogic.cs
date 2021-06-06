using AutoMapper;
using Fait.DAL;
using FaitLogic.DTO;
using FaitLogic.Enums;
using FaitLogic.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class YearPlanLogic
    {
        private readonly IMapper mapper;

        private readonly IYearPlanRepository yearPlanRepo;
        private readonly ISubjectRepository subjectRepo;
        private readonly IGroupRepository groupRepo;

        public YearPlanLogic(
            IMapper mapper,
            IYearPlanRepository yearPlanRepository,
            IGroupRepository groupRepository,
            ISubjectRepository subjectRepository)
        {
            this.mapper = mapper;
            yearPlanRepo = yearPlanRepository;
            groupRepo = groupRepository;
            subjectRepo = subjectRepository;
        }

        public YearPlanDTO ShowYearPlan(int yearPlanId)
        {
            var yearPlan = yearPlanRepo.FindYearPlan(yearPlanId);

            var groupsNames = groupRepo.FindGroupsByYearPlan(yearPlanId).Select(x =>x.GroupPrefix.Name);
            var yearPlanDto = new YearPlanDTO
            {
                PlanName = yearPlan.PlanName,
                Course = yearPlan.Course,
                Groups = string.Join(',', groupsNames)
            };

            var subjects = subjectRepo.FindSubjectsInfo(yearPlanId);

            var subjectsDto = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                var subj = new SubjectDTO
                {
                    SubName = subject.SubName,
                    SubHoursAndETCS = string.Format($"{subject.SubHours}/{subject.Ects}"),
                    Faculty = subject.Faculty
                };

                var sb = subjectRepo.FindSubjects(subject.Id);

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

            yearPlanDto.SubjectInfo = subjectsDto;

            return yearPlanDto;
        }

        public int? AddYearPlan(YearPlanDTO yearPlanInfo)
        {
            var yearPlan = new YearPlan
            {
                PlanName = yearPlanInfo.PlanName,
                Course = (byte)yearPlanInfo.Course
            };

            var yearPlanId = yearPlanRepo.AddYearPlan(yearPlan);

            foreach (var subject in yearPlanInfo.SubjectInfo)
            {
                AddSubjects(subject, yearPlanId);
            }

            return yearPlanId;
        }

        public ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course)
        {
            var list = yearPlanRepo.GetListOfYearPlans(course);
            var yearPlans = mapper.Map<List<YearPlan>, List<YearPlanNameWithIdDTO>>(yearPlanRepo.GetListOfYearPlans(course));

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

            var subjectInfoId = subjectRepo.AddSubjectInfo(subjectInfo);

            if (subjectDto.SpringMonitoring != (int)MonitoringEnum.SemesterNotExist && subjectDto.SpringTask != (int)TaskEnum.SemesterNotExist)
            {
                var springSubject = new Subject
                {
                    SubjectInfoId = subjectInfoId.Value,
                    Monitoring = subjectDto.SpringMonitoring,
                    Task = subjectDto.SpringTask,
                    Semester = (int)SemesterEnum.Spring
                };
                subjectRepo.AddSubject(springSubject);
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
                subjectRepo.AddSubject(autumnSubject);
            }
        }
    }
}

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
                Name = yearPlan.Name,
                Year = yearPlan.Year,
                GroupIds = (ICollection<int>)groupsNames
            };

            var subjects = subjectRepo.FindSubjects(yearPlanId);

            var subjectsDto = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                var subj = mapper.Map<Subject, SubjectDTO>(subject);

                var sb = subjectRepo.FindSubjectSemesters(subject.Id);

                var autumn = sb.Find(x => x.Semester == (int)SemesterEnum.Autumn);
                if (autumn != null)
                {
                    subj.ControlTypeFall = autumn.ControlType;
                    subj.IsIndividualTaskExistFall = autumn.IsIndividualTaskExist;
                }

                var spring = sb.Find(x => x.Semester == (int)SemesterEnum.Spring);
                if (spring != null)
                {
                    subj.ControlTypeSpring = spring.ControlType;
                    subj.IsIndividualTaskExistSpring = spring.IsIndividualTaskExist;
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
                Name = yearPlanInfo.Name,
                Year = yearPlanInfo.Year
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
            var subjectInfo = mapper.Map<SubjectDTO, Subject>(subjectDto);
            subjectInfo.PlanId = yearPlanId;

            var subjectInfoId = subjectRepo.AddSubject(subjectInfo);

            if (subjectDto.ControlTypeSpring != (int)MonitoringEnum.SemesterNotExist)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlType = subjectDto.ControlTypeSpring,
                    IsIndividualTaskExist = subjectDto.IsIndividualTaskExistSpring,
                    Semester = (int)SemesterEnum.Spring
                };
                subjectRepo.AddSubjectSemester(springSubject);
            }

            if (subjectDto.ControlTypeFall != (int)MonitoringEnum.SemesterNotExist)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlType = subjectDto.ControlTypeFall,
                    IsIndividualTaskExist = subjectDto.IsIndividualTaskExistFall,
                    Semester = (int)SemesterEnum.Autumn
                };
                subjectRepo.AddSubjectSemester(autumnSubject);
            }
        }
    }
}

using AutoMapper;
using Fait.DAL;
using Fait.DAL.Repository.UnitOfWork;
using FaitLogic.DTO;
using FaitLogic.Enums;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Logic
{
    public class YearPlanLogic
    {
        private readonly IMapper mapper;

        private readonly IUnitOfWork unitOfWork;

        public YearPlanLogic(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public YearPlanDTO ShowYearPlan(int yearPlanId)
        {
            var yearPlan = unitOfWork.YearPlanRepository.FindYearPlan(yearPlanId);

            //var groupsNames = groupRepo.FindGroupsByYearPlan(yearPlanId).Select(x =>x.GroupPrefix.Name);
            var yearPlanDto = new YearPlanDTO
            {
                Name = yearPlan.Name,
                Year = yearPlan.Year
            };

            var subjects = unitOfWork.SubjectRepository.FindSubjects(yearPlanId);

            var subjectsDto = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                var subj = mapper.Map<Subject, SubjectDTO>(subject);

                var sb = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(subject.Id).ToList();

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

            unitOfWork.YearPlanRepository.AddYearPlan(yearPlan);
            unitOfWork.Save();
            var yearPlanId = unitOfWork.YearPlanRepository.GetLastYearPlanId();

            foreach (var subject in yearPlanInfo.SubjectInfo)
            {
                AddSubjects(subject, yearPlanId);
            }

            return yearPlanId;
        }

        public ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course)
        {
            var yearPlans = mapper.Map<List<YearPlan>, List<YearPlanNameWithIdDTO>>(unitOfWork.YearPlanRepository.GetListOfYearPlans(course));

            return yearPlans;
        }

        public YearPlanNameWithIdDTO GetYearPlanByGroup(int groupId)
        {
            var yearPlan = mapper.Map<YearPlan, YearPlanNameWithIdDTO>(unitOfWork.YearPlanRepository.GetYearPlanByGroup(groupId));

            return yearPlan;
        }

        private void AddSubjects(SubjectDTO subjectDto, int? yearPlanId)
        {
            var subjectInfo = mapper.Map<SubjectDTO, Subject>(subjectDto);
            subjectInfo.PlanId = yearPlanId;

            unitOfWork.SubjectRepository.AddSubject(subjectInfo);
            unitOfWork.Save();
            var subjectInfoId = unitOfWork.SubjectRepository.GetLastSubjectId();

            if (subjectDto.ControlTypeSpring != (int)MonitoringEnum.SemesterNotExist)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlType = subjectDto.ControlTypeSpring,
                    IsIndividualTaskExist = subjectDto.IsIndividualTaskExistSpring,
                    Semester = (int)SemesterEnum.Spring
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
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
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(autumnSubject);
            }
            unitOfWork.Save();
        }
    }
}

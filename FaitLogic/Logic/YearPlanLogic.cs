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
                var subjectDto = mapper.Map<Subject, SubjectDTO>(subject);

                var subjectSemesters = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(subject.Id).ToList();

                var autumn = subjectSemesters.Find(x => x.Semester == (int)SemesterEnum.Autumn);
                if (autumn != null)
                {
                    subjectDto.ControlTypeFall = autumn.ControlType;
                    subjectDto.IsIndividualTaskExistFall = autumn.IsIndividualTaskExist;
                }

                var spring = subjectSemesters.Find(x => x.Semester == (int)SemesterEnum.Spring);
                if (spring != null)
                {
                    subjectDto.ControlTypeSpring = spring.ControlType;
                    subjectDto.IsIndividualTaskExistSpring = spring.IsIndividualTaskExist;
                }
                subjectsDto.Add(subjectDto);
            }

            yearPlanDto.SubjectInfo = subjectsDto;

            return yearPlanDto;
        }

        public void AddYearPlan(YearPlanDTO yearPlanInfo)
        {
            var yearPlan = new YearPlan
            {
                Name = yearPlanInfo.Name,
                Year = yearPlanInfo.Year
            };

            unitOfWork.YearPlanRepository.AddYearPlan(yearPlan);
            unitOfWork.Save();
            var yearPlanId = unitOfWork.YearPlanRepository.GetLastYearPlanId();

            foreach (var groupId in yearPlanInfo.GroupIds)
            {
                unitOfWork.YearPlanGroupsRepository.AddYearPlanGroups(new YearPlanGroup { YearPlanId = yearPlanId , GroupId = groupId });
            }

            foreach (var subject in yearPlanInfo.SubjectInfo)
            {
                AddSubjects(subject, yearPlanId);
            }
            unitOfWork.Save();
        }

        public void UpdateYearPlan(YearPlanDTO yearPlanInfo, int yearPlanId)
        {

            var yearPlan = unitOfWork.YearPlanRepository.FindYearPlan(yearPlanId);

            yearPlan.Name = yearPlanInfo.Name;
            yearPlan.Year = yearPlanInfo.Year;

            var oldSubjects = unitOfWork.SubjectRepository.FindSubjects(yearPlanId);

            foreach (var newSubject in yearPlanInfo.SubjectInfo)
            {
                var oldSubject = oldSubjects.FirstOrDefault(x => x.Id == newSubject.Id);
                if (oldSubject != null)
                {
                    UpdateSubjects(newSubject, oldSubject);
                }
                else
                {
                    AddSubjects(newSubject, yearPlanId);
                }
            }
            unitOfWork.Save();
        }

        public ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course)
        {
            var yearPlans = mapper.Map<List<YearPlan>, List<YearPlanNameWithIdDTO>>(unitOfWork.YearPlanRepository.GetListOfYearPlans(course));

            return yearPlans;
        }

        public YearPlanNameWithIdDTO GetYearPlanByGroup(int groupId, int year)
        {
            var yearPlan = mapper.Map<YearPlan, YearPlanNameWithIdDTO>(unitOfWork.YearPlanRepository.GetYearPlanByGroup(groupId, year));

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
        }

        private void UpdateSubjects(SubjectDTO newSubject, Subject oldSubject)
        {
            oldSubject.Hours = newSubject.Hours;
            oldSubject.Ects = newSubject.Ects;
            oldSubject.Department = newSubject.Department;

            var subjectSemesters = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(oldSubject.Id).ToList();

            var subjectSpring = subjectSemesters.FirstOrDefault(x => x.Semester == (int)SemesterEnum.Spring);
            if (newSubject.ControlTypeSpring == (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectSpring);
            }
            else if (newSubject.ControlTypeSpring != (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                subjectSpring.IsIndividualTaskExist = newSubject.IsIndividualTaskExistSpring;
                subjectSpring.ControlType = newSubject.ControlTypeSpring;
            }
            else if (newSubject.ControlTypeSpring != (int)MonitoringEnum.SemesterNotExist && subjectSpring == null)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlType = newSubject.ControlTypeSpring,
                    IsIndividualTaskExist = newSubject.IsIndividualTaskExistSpring,
                    Semester = (int)SemesterEnum.Spring
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
            }

            var subjectFall = subjectSemesters.FirstOrDefault(x => x.Semester == (int)SemesterEnum.Autumn);
            if (newSubject.ControlTypeFall == (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectFall);
            }
            else if (newSubject.ControlTypeFall != (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                subjectFall.IsIndividualTaskExist = newSubject.IsIndividualTaskExistFall;
                subjectFall.ControlType = newSubject.ControlTypeFall;
            }
            else if (newSubject.ControlTypeFall != (int)MonitoringEnum.SemesterNotExist && subjectFall == null)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlType = newSubject.ControlTypeFall,
                    IsIndividualTaskExist = newSubject.IsIndividualTaskExistFall,
                    Semester = (int)SemesterEnum.Autumn
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(autumnSubject);
            }
        }
    }
}

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
    public class YearPlanLogic : IYearPlanLogic
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
                Id = yearPlan.Id,
                Name = yearPlan.Name,
                Year = yearPlan.Year
            };

            var subjects = unitOfWork.SubjectRepository.FindSubjects(yearPlanId);

            var subjectsDto = new List<SubjectDTO>();
            foreach (var subject in subjects)
            {
                var subjectDto = mapper.Map<Subject, SubjectDTO>(subject);

                var subjectSemesters = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(subject.Id).ToList();

                var autumn = subjectSemesters.Find(x => x.SemesterId == (int)SemesterEnum.Autumn);
                if (autumn != null)
                {
                    subjectDto.ControlFallType = autumn.ControlTypeId;
                    subjectDto.IndividualTaskFallType = autumn.IndividualTaskType;
                }

                var spring = subjectSemesters.Find(x => x.SemesterId == (int)SemesterEnum.Spring);
                if (spring != null)
                {
                    subjectDto.ControlSpringType = spring.ControlTypeId;
                    subjectDto.IndividualTaskSpringType = spring.IndividualTaskType;
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
                unitOfWork.YearPlanGroupsRepository.AddYearPlanGroups(new YearPlanGroup { YearPlanId = yearPlanId, GroupId = groupId });
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

            if (oldSubjects.Count > yearPlanInfo.SubjectInfo.Count)
            {
                var newSubjectsIds = yearPlanInfo.SubjectInfo.Select(x => x.Id);
                foreach (var oldSubject in oldSubjects)
                {
                    if (!newSubjectsIds.Contains(oldSubject.Id))
                    {
                        DeleteSubject(oldSubject);
                    }
                }

            }

            unitOfWork.Save();
        }

        public ICollection<YearPlanNameWithIdDTO> GetYearPlans(int course)
        {
            var yearPlans = mapper.Map<List<YearPlan>, List<YearPlanNameWithIdDTO>>(unitOfWork.YearPlanRepository.GetListOfYearPlans(course));

            return yearPlans;
        }

        public int? GetYearPlanIdByGroup(int groupId, int year)
        {
            return unitOfWork.YearPlanRepository.GetYearPlanIdByGroup(groupId, year);
        }

        private void AddSubjects(SubjectDTO subjectDto, int? yearPlanId)
        {
            var subjectInfo = mapper.Map<SubjectDTO, Subject>(subjectDto);
            subjectInfo.PlanId = yearPlanId;

            unitOfWork.SubjectRepository.AddSubject(subjectInfo);
            unitOfWork.Save();
            var subjectInfoId = unitOfWork.SubjectRepository.GetLastSubjectId();

            if (subjectDto.ControlSpringType != (int)MonitoringEnum.SemesterNotExist)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlTypeId = subjectDto.ControlSpringType,
                    IndividualTaskType = subjectDto.IndividualTaskSpringType,
                    SemesterId = (int)SemesterEnum.Spring
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
            }

            if (subjectDto.ControlFallType != (int)MonitoringEnum.SemesterNotExist)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlTypeId = subjectDto.ControlFallType,
                    IndividualTaskType = subjectDto.IndividualTaskFallType,
                    SemesterId = (int)SemesterEnum.Autumn
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(autumnSubject);
            }
        }

        private void UpdateSubjects(SubjectDTO newSubject, Subject oldSubject)
        {
            oldSubject.Name = newSubject.Name;
            oldSubject.Hours = newSubject.Hours;
            oldSubject.Ects = newSubject.Ects;
            oldSubject.Department = newSubject.Department;

            var subjectSemesters = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(oldSubject.Id).ToList();

            var subjectSpring = subjectSemesters.FirstOrDefault(x => x.SemesterId == (int)SemesterEnum.Spring);
            if (newSubject.ControlSpringType == (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectSpring);
            }
            else if (newSubject.ControlSpringType != (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                subjectSpring.IndividualTaskType = newSubject.IndividualTaskSpringType;
                subjectSpring.ControlTypeId = newSubject.ControlSpringType;
            }
            else if (newSubject.ControlSpringType != (int)MonitoringEnum.SemesterNotExist && subjectSpring == null)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlTypeId = newSubject.ControlSpringType,
                    IndividualTaskType = newSubject.IndividualTaskSpringType,
                    SemesterId = (int)SemesterEnum.Spring
                };

                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
            }

            var subjectFall = subjectSemesters.FirstOrDefault(x => x.SemesterId == (int)SemesterEnum.Autumn);
            if (newSubject.ControlFallType == (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectFall);
            }
            else if (newSubject.ControlFallType != (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                subjectFall.IndividualTaskType = newSubject.IndividualTaskFallType;
                subjectFall.ControlTypeId = newSubject.ControlFallType;
            }
            else if (newSubject.ControlFallType != (int)MonitoringEnum.SemesterNotExist && subjectFall == null)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlTypeId = newSubject.ControlFallType,
                    IndividualTaskType = newSubject.IndividualTaskFallType,
                    SemesterId = (int)SemesterEnum.Autumn
                };

                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(autumnSubject);
            }
        }

        private void DeleteSubject(Subject oldSubject)
        {
            var subjectSemesters = unitOfWork.SubjectSemesterRepository.FindSubjectSemesters(oldSubject.Id);

            foreach (var subjectSemester in subjectSemesters)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectSemester);
            }
            unitOfWork.SubjectRepository.DeleteSubject(oldSubject);
        }
    }
}

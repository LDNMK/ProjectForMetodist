﻿using AutoMapper;
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

                var autumn = subjectSemesters.Find(x => x.Semester == (int)SemesterEnum.Autumn);
                if (autumn != null)
                {
                    subjectDto.ControlFallType = autumn.ControlType;
                    subjectDto.IndividualTaskFallType = autumn.IndividualTaskType;
                }

                var spring = subjectSemesters.Find(x => x.Semester == (int)SemesterEnum.Spring);
                if (spring != null)
                {
                    subjectDto.ControlSpringType = spring.ControlType;
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
                    ControlType = subjectDto.ControlSpringType,
                    IndividualTaskType = subjectDto.IndividualTaskSpringType,
                    Semester = (int)SemesterEnum.Spring
                };
                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
            }

            if (subjectDto.ControlFallType != (int)MonitoringEnum.SemesterNotExist)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = subjectInfoId,
                    ControlType = subjectDto.ControlFallType,
                    IndividualTaskType = subjectDto.IndividualTaskFallType,
                    Semester = (int)SemesterEnum.Autumn
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

            var subjectSpring = subjectSemesters.FirstOrDefault(x => x.Semester == (int)SemesterEnum.Spring);
            if (newSubject.ControlSpringType == (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectSpring);
            }
            else if (newSubject.ControlSpringType != (int)MonitoringEnum.SemesterNotExist && subjectSpring != null)
            {
                subjectSpring.IndividualTaskType = newSubject.IndividualTaskSpringType;
                subjectSpring.ControlType = newSubject.ControlSpringType;
            }
            else if (newSubject.ControlSpringType != (int)MonitoringEnum.SemesterNotExist && subjectSpring == null)
            {
                var springSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlType = newSubject.ControlSpringType,
                    IndividualTaskType = newSubject.IndividualTaskSpringType,
                    Semester = (int)SemesterEnum.Spring
                };

                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(springSubject);
            }

            var subjectFall = subjectSemesters.FirstOrDefault(x => x.Semester == (int)SemesterEnum.Autumn);
            if (newSubject.ControlFallType == (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                unitOfWork.SubjectSemesterRepository.DeleteSubjectSemester(subjectFall);
            }
            else if (newSubject.ControlFallType != (int)MonitoringEnum.SemesterNotExist && subjectFall != null)
            {
                subjectFall.IndividualTaskType = newSubject.IndividualTaskFallType;
                subjectFall.ControlType = newSubject.ControlFallType;
            }
            else if (newSubject.ControlFallType != (int)MonitoringEnum.SemesterNotExist && subjectFall == null)
            {
                var autumnSubject = new SubjectSemester
                {
                    SubjectId = oldSubject.Id,
                    ControlType = newSubject.ControlFallType,
                    IndividualTaskType = newSubject.IndividualTaskFallType,
                    Semester = (int)SemesterEnum.Autumn
                };

                unitOfWork.SubjectSemesterRepository.AddSubjectSemester(autumnSubject);
            }
        }
    }
}

using Fait.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaitLogic.Repository
{
    public class CurriculumRepository
    {
        private readonly FAIT4Context dbContext;

        public CurriculumRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public YearPlan FindYearPlan(int yearPlanId)
        {
            return dbContext.YearPlans.Where(x => x.Id == yearPlanId).Single();
        }

        public ICollection<Group> FindGroupsByYearPlan(int yearPlanId)
        {
            return dbContext.Groups.Include(x=>x.GroupName).Where(x => x.PlanId == yearPlanId).ToList();
        }

        public List<SubjectInfo> FindSubjectsInfo(int curriculumId)
        {
            return dbContext.SubjectInfos.Where(x => x.PlanId == curriculumId).ToList();
        }

        public List<Subject> FindSubjects(int subjectId)
        {
            return dbContext.Subjects.Where(x => x.SubjectInfoId == subjectId).ToList();
        }

        public List<YearPlan> GetListOfYearPlans(int course)
        {
            return dbContext.YearPlans.Where(x => x.Course == course).ToList();
        }


        public int? AddYearPlan(YearPlan yearPlan)
        {
            dbContext.YearPlans.Add(yearPlan);
            dbContext.SaveChanges();

            return dbContext.YearPlans.OrderBy(x =>x.Id).LastOrDefault()?.Id;
        }

        public int? AddSubjectInfo(SubjectInfo subjectInfo)
        {
            dbContext.SubjectInfos.Add(subjectInfo);
            dbContext.SaveChanges();

            return dbContext.SubjectInfos.OrderBy(x => x.Id).LastOrDefault()?.Id;
        }

        public void AddSubject(Subject subject)
        {
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
        }
    }
}

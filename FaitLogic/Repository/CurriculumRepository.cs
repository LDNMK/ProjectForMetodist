using Fait.DAL;
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

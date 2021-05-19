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
        { if (!IsExsistYearPlan(yearPlan.PlanName, yearPlan.PlanYear))
            {
                dbContext.YearPlans.Add(yearPlan);
                dbContext.SaveChanges();

                return dbContext.YearPlans.LastOrDefault()?.Id;
            }
            return 0;
        }

        public int? AddSubjectInfo(SubjectInfo subjectInfo)
        {
            if (!IsExsistSubjectInfo(subjectInfo.SubName, subjectInfo.PlanId))
            {
                dbContext.SubjectInfos.Add(subjectInfo);
                dbContext.SaveChanges();

                return dbContext.SubjectInfos.LastOrDefault()?.Id;
            }
            return 0;
        }

        public void AddSubject(Subject subject)
        { if (!IsExsistSubject(subject.SubjectInfo.SubName, subject.SubjectInfo.PlanId, subject.Semester))
            {
                dbContext.Subjects.Add(subject);
                dbContext.SaveChanges();
            }
        }
        public bool IsExsistSubject(string subjectName, int? planId, byte semester)
        {
            
                return dbContext.Subjects.Where(s => s.SubjectInfo.PlanId == planId &&
                s.SubjectInfo.SubName.ToLower() == subjectName.ToLower()
                && s.Semester == semester).Any();
            
        }
        public bool IsExsistYearPlan(string  yearPlanName,int planYear)
        {
            return dbContext.YearPlans.Where(p => p.PlanName.ToLower() == yearPlanName.ToLower() && p.PlanYear == planYear).Any();
        }
        public bool IsExsistSubjectInfo(string subjectName, int? planId)
        {
            return dbContext.SubjectInfos.Where(s => s.SubName.ToLower() == subjectName.ToLower() && s.PlanId == planId).Any();
        }

    }
}

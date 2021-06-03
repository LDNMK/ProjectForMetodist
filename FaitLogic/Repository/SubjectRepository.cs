using Fait.DAL;
using FaitLogic.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly FAIT4Context dbContext;

        public SubjectRepository(FAIT4Context context)
        {
            dbContext = context;
        }

        public List<SubjectInfo> FindSubjectsInfo(int yearPlanId)
        {
            return dbContext.SubjectInfos
                .Where(x => x.PlanId == yearPlanId)
                .ToList();
        }

        public List<Subject> FindSubjects(int subjectId)
        {
            return dbContext.Subjects
                .Where(x => x.SubjectInfoId == subjectId)
                .ToList();
        }

        public int? AddSubjectInfo(SubjectInfo subjectInfo)
        {
            dbContext.SubjectInfos.Add(subjectInfo);
            dbContext.SaveChanges();

            return dbContext.SubjectInfos
                .OrderBy(x => x.Id)
                .LastOrDefault()?.Id;
        }

        public void AddSubject(Subject subject)
        {
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
        }
    }
}

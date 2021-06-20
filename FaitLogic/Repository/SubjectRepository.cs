using Fait.DAL;
using FaitLogic.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FaitLogic.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly FAITContext dbContext;

        public SubjectRepository(FAITContext context)
        {
            dbContext = context;
        }

        public List<Subject> FindSubjects(int yearPlanId)
        {
            return dbContext.Subjects
                .Where(x => x.PlanId == yearPlanId)
                .ToList();
        }

        public List<SubjectSemester> FindSubjectSemesters(int subjectId)
        {
            return dbContext.SubjectSemesters
                .Where(x => x.Id == subjectId)
                .ToList();
        }

        public int AddSubject(Subject subjectInfo)
        {
            dbContext.Subjects.Add(subjectInfo);
            dbContext.SaveChanges();

            return dbContext.Subjects
                .OrderBy(x => x.Id)
                .LastOrDefault().Id;
        }

        public void AddSubjectSemester(SubjectSemester subject)
        {
            dbContext.SubjectSemesters.Add(subject);
            dbContext.SaveChanges();
        }
    }
}

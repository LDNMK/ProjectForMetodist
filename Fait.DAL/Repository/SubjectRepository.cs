using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(FAITContext context)
            : base(context)
        {
        }

        public ICollection<Subject> FindSubjects(int yearPlanId)
        {
            return base.Find(x => x.PlanId == yearPlanId);
        }

        public void AddSubject(Subject subjectInfo)
        {
            base.Add(subjectInfo);
        }

        public void DeleteSubject(Subject subjectInfo)
        {
            base.Delete(subjectInfo);
        }

        public int GetLastSubjectId()
        {
            return dbContext.Subjects
                .OrderBy(x => x.Id)
                .LastOrDefault().Id;
        }
    }
}

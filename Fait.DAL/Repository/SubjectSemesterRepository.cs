using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System.Collections.Generic;

namespace Fait.DAL.Repository
{
    public class SubjectSemesterRepository: Repository<SubjectSemester>, ISubjectSemesterRepository
    {
        public SubjectSemesterRepository(FAITContext context)
            : base(context)
        {
        }

        public ICollection<SubjectSemester> FindSubjectSemesters(int subjectId)
        {
            return base.Find(x => x.SubjectId == subjectId);
            //return dbContext.SubjectSemesters
            //    .Where(x => x.Id == subjectId)
            //    .ToList();
        }

        public void AddSubjectSemester(SubjectSemester subject)
        {
            base.Add(subject);
        }

        public void DeleteSubjectSemester(SubjectSemester subject)
        {
            base.Delete(subject);
        }
    }
}

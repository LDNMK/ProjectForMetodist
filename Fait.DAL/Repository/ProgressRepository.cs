using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fait.DAL.Repository
{
    public class ProgressRepository : Repository<Mark>, IProgressRepository
    {
        public ProgressRepository(FAITContext context)
            : base(context)
        {
        }

        public void AddMark(Mark mark)
        {
            base.Add(mark);
        }

        public void UpdateMark(Mark mark)
        {
            base.Update(mark);
        }

        public void DeleteMark(Mark mark)
        {
            base.Delete(mark);
        }

        public ICollection<int> GetStudentMarks(int studentId)
        {
            return base.Find(x => x.StudentId == studentId)
                .Select(x => x.SubjectMark.GetValueOrDefault() + x.TaskMark.GetValueOrDefault())
                .ToList();
        }

        public ICollection<Mark> FindMarksBySubject(ICollection<int> subjectIds)
        {
            return base.Find(x => subjectIds.Contains(x.SubjectId));
        }

        public Mark FindMark(int subjectId, int studentId)
        {
            return base.Find(x => x.SubjectId ==subjectId && x.StudentId == studentId)
                .FirstOrDefault();
        }
    }
}

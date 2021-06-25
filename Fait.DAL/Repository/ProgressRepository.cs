using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
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

        public ICollection<Mark> FindMarksBySubject(ICollection<int> subjectIds)
        {
            return base.Find(x => subjectIds.Contains(x.SubjectId));
        }
    }
}

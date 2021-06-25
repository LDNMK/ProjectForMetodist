using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class ActualGroupRepository : Repository<ActualGroup>, IActualGroupRepository
    {
        public ActualGroupRepository(FAITContext context)
            : base(context)
        {
        }

        public void AddActualGroup(ActualGroup actualGroup)
        {
            base.Add(actualGroup);
        }

        public void AddActualGroups(ICollection<ActualGroup> actualGroups)
        {
            base.AddRange(actualGroups);
        }

        public ActualGroup FindStudentActualGroup(int studentId)
        {
            return base.Find(x => x.StudentId == studentId 
                && x.Group.Actual == true)
                .SingleOrDefault();
            //return dbContext.ActualGroups
            //    .Where(x => x.StudentId == studentId && x.Group.Actual == true)
            //    .SingleOrDefault();
        }

        public void UpdateActualGroup(ActualGroup group)
        {
            base.Update(group);
        }
    }
}

using Fait.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Fait.DAL.Repository
{
    public class ActualGroupRepository : IActualGroupRepository
    {
        private readonly FAITContext dbContext;

        public ActualGroupRepository(FAITContext context)
        {
            dbContext = context;
        }

        public void AddActualGroup(ActualGroup actualGroup)
        {
            //TODO: some error
            dbContext.ActualGroups.Add(actualGroup);
            dbContext.SaveChanges();
        }

        public void AddActualGroups(ICollection<ActualGroup> actualGroups)
        {
            dbContext.ActualGroups.AddRange(actualGroups);
            dbContext.SaveChanges();
        }

        public ActualGroup FindStudentActualGroup(int studentId)
        {
            return dbContext.ActualGroups
                .Where(x => x.StudentId == studentId && x.Group.Actual == true)
                .SingleOrDefault();
        }

        public void UpdateActualGroup(ActualGroup group)
        {
            dbContext.ActualGroups.Update(group);
            dbContext.SaveChanges();
        }
    }
}

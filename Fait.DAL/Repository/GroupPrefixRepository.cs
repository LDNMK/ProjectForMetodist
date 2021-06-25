using Fait.DAL.Repository.IRepository;
using Fait.DAL.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fait.DAL.Repository
{
    public class GroupPrefixRepository : Repository<GroupPrefix>,  IGroupPrefixRepository
    {
        public GroupPrefixRepository(FAITContext context)
            : base(context)
        {
        }

        public void CreateNewGroupName(GroupPrefix groupName)
        {
            base.Add(groupName);
            //var lastGroupNameId = dbContext.GroupPrefixes
            //    .OrderByDescending(x => x.Id)
            //    .FirstOrDefault().Id;
        }

        public int? FindGroupName(string groupName)
        {
            return dbContext.GroupPrefixes
                .SingleOrDefault(x => x.Name == groupName)?.Id;
        }

        public int GetLastGroupPrefixId()
        {
            return dbContext.GroupPrefixes
                .OrderBy(x => x.Id)
                .LastOrDefault().Id;
        }
    }
}

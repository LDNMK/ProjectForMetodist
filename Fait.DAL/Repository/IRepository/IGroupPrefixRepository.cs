using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IGroupPrefixRepository
    {
        void CreateNewGroupName(GroupPrefix groupName);

        int? FindGroupName(string groupName);

        int GetLastGroupPrefixId();
    }
}

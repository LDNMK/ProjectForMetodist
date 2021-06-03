using Fait.DAL;
using System.Collections.Generic;

namespace FaitLogic.Repository.IRepository
{
    public interface IActualGroupRepository
    {
        void UpdateActualGroup(ActualGroup group);

        ActualGroup FindStudentActualGroup(int studentId);

        void AddActualGroup(ActualGroup actualGroup);

        void AddActualGroups(ICollection<ActualGroup> actualGroups);
    }
}

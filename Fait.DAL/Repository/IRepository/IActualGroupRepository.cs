using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IActualGroupRepository
    {
        void UpdateActualGroup(ActualGroup group);

        ActualGroup FindStudentActualGroup(int studentId);

        void AddActualGroup(ActualGroup actualGroup);

        void AddActualGroups(ICollection<ActualGroup> actualGroups);
    }
}

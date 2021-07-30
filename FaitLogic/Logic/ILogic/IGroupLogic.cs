using FaitLogic.DTO;
using System.Collections.Generic;

namespace FaitLogic.Logic.ILogic
{
    public interface IGroupLogic
    {
        //void ActivateGroups(int[] groupsIds);
        void AddGroup(string groupName);
        //ICollection<GroupNameWithIdDTO> GetDeactivatedGroups();
        ICollection<GroupNameWithIdDTO> GetGroups(int course, int? year);
    }
}
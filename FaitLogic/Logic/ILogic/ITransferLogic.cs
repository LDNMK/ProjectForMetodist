using FaitLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaitLogic.Logic.ILogic
{
    public interface ITransferLogic
    {
        Task<ICollection<TransferStudentDTO>> GetStudents(int groupId, int year);
        Task TransferStudents(ICollection<TransferStudentDTO> students);
    }
}
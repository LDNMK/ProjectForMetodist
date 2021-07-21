using System.Collections.Generic;

namespace Fait.DAL.Repository.IRepository
{
    public interface IStudentTransferHistoryRepository
    {
        void AddTransferHistory(StudentTransferHistory sth);

        ICollection<StudentTransferHistory> GetStudentTransferHistory(int studentId);

        void UpdateStudentTransferHistories(ICollection<StudentTransferHistory> histories);
    }
}

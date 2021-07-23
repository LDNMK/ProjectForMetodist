using Fait.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class StudentTransferHistoryRepository : Repository<StudentTransferHistory>, IStudentTransferHistoryRepository
    {
        public StudentTransferHistoryRepository(FAITContext context)
            : base(context)
        {

        }

        public void AddTransferHistory(StudentTransferHistory sth)
        {
            base.Add(sth);
        }

        public ICollection<StudentTransferHistory> GetStudentTransferHistory(int studentId)
        {
            return base.Find(x => x.StudentId == studentId);
        }

        public void UpdateStudentTransferHistories(ICollection<StudentTransferHistory> histories)
        {
            base.UpdateRange(histories);
        }
    }
}

using Fait.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository
{
    public class TransferHistoryRepository : Repository<StudentTransferHistory>, ITransferHistoryRepository
    {
        public TransferHistoryRepository(FAITContext context)
            : base(context)
        {

        }

        public void AddTransferHistory(StudentTransferHistory sth)
        {
            base.Add(sth);
        }
    }
}

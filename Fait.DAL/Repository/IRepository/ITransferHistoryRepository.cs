using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface ITransferHistoryRepository
    {
        void AddTransferHistory(StudentTransferHistory sth);
    }
}

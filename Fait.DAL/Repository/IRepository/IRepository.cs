using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IRepository
    {
        void Submit();
    }

    public interface IRepository<T> : IRepository
    where T : class
    {
    }
}

using System;
using System.Collections.Generic;

namespace Fait.DAL.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Register(IRepository.IRepository repository);
    }
}

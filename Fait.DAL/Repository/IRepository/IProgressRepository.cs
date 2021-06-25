using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IProgressRepository
    {
        void AddMark(Mark mark);

        void UpdateMark(Mark mark);

        ICollection<Mark> FindMarksBySubject(ICollection<int> subjectIds);
    }
}

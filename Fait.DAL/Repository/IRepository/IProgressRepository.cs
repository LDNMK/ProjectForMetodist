using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface IProgressRepository
    {
        void AddMark(Mark mark);

        void UpdateMark(Mark mark);

        void DeleteMark(Mark mark);

        ICollection<Mark> FindMarksBySubject(ICollection<int> subjectIds);

        Mark FindMark(int subjectId, int studentId);

        ICollection<int> GetStudentMarks(int studentId);
    }
}

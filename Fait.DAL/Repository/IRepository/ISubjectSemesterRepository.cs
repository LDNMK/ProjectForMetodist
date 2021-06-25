using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.DAL.Repository.IRepository
{
    public interface ISubjectSemesterRepository
    {
        ICollection<SubjectSemester> FindSubjectSemesters(int subjectId);

        void AddSubjectSemester(SubjectSemester subject);

        void DeleteSubjectSemester(SubjectSemester subject);
    }
}

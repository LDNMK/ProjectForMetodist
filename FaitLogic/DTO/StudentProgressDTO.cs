using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class StudentProgressDTO
    {
        public int Course { get; set; }

        public ICollection<StudentSubjectDTO> Subjects { get; set; }
    }

    public class StudentSubjectDTO
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Ects { get; set; }
        public string Department { get; set; }

        public virtual ICollection<StudentSubjectSemesterDTO> SubjectSemesters { get; set; }
    }

    public class StudentSubjectSemesterDTO
    {
        public byte SemesterId { get; set; }

        public int Mark { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}

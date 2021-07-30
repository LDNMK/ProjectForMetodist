using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class ControlType
    {
        public ControlType()
        {
            SubjectSemesters = new HashSet<SubjectSemester>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubjectSemester> SubjectSemesters { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int SubjectInfoId { get; set; }
        public bool Monitoring { get; set; }
        public bool Task { get; set; }
        public bool Semester { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}

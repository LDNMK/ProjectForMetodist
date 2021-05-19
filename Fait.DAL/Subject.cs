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
        public Byte Monitoring { get; set; }
        public Byte Task { get; set; }
        public Byte Semester { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}

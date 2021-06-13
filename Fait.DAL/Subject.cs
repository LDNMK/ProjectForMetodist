using System.Collections.Generic;

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
        public byte Monitoring { get; set; }
        public byte Task { get; set; }
        public byte Semester { get; set; }

        public virtual SubjectInfo SubjectInfo { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}

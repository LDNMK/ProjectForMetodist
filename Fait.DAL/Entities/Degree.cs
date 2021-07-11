using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Degree
    {
        public Degree()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}

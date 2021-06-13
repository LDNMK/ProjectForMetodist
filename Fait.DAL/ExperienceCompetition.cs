using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class ExperienceCompetition
    {
        public ExperienceCompetition()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}

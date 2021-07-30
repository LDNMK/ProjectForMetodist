using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class ExperienceCompetition
    {
        public ExperienceCompetition()
        {
            StudentInfos = new HashSet<StudentInfo>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentInfo> StudentInfos { get; set; }
    }
}

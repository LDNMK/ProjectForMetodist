using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class ExpirienceCompetitione
    {
        public ExpirienceCompetitione()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }
        public string ExpirienceName { get; set; }

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}

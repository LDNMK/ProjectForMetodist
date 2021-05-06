using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            StudentsInfos = new HashSet<StudentsInfo>();
        }

        public byte Id { get; set; }
        public string MaritalStatusName { get; set; }

        public virtual ICollection<StudentsInfo> StudentsInfos { get; set; }
    }
}

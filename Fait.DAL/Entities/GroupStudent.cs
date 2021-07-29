using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class GroupStudent
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public int GroupYear { get; set; }
        public bool IsActive { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}

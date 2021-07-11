using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class ActualGroup
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentState
    {
        public StudentState()
        {
            Students = new HashSet<Student>();
        }

        public byte Id { get; set; }
        public string StudentStateName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

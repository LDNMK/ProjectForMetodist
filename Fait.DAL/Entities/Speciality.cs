using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Speciality
    {
        public Speciality()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string SpecialityName { get; set; }      // специальность

        public virtual ICollection<Student> Students { get; set; }
    }
}

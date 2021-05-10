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
        public byte Kode { get; set; }//код
        public string SpecialityName { get; set; }//специальность
        public string SpecializationName { get; set; }//специализация

        public virtual ICollection<Student> Students { get; set; }
    }
}

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
        public string Speciality1 { get; set; }//специальность
        public string Specialization { get; set; }//специализация

        public virtual ICollection<Student> Students { get; set; }
    }
}

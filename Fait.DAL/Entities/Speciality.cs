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

        public string Name { get; set; }                            // Название специальности

        public bool IsOnlyForMasterDegree { get; set; } = false;    // Фильтр для магистров

        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class StudentState
    {
        public StudentState()
        {
            StudentTransferHistories = new HashSet<StudentTransferHistory>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
            /*  на условиях полной компенсации:
                -- 1 Перехід з курсу на курс
                -- 2 Перерва в академічному навчанні
                -- 3 Студент відрахований
                -- 4 Студент отримав ступінь
            */

        public virtual ICollection<StudentTransferHistory> StudentTransferHistories { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

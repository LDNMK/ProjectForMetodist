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
            /*  на условиях полной компенсации:
                -- 1 Переход в другую группу автоматически
                -- 2 Студент в академ отпуске
                -- 3 Студент переходит в другую группу
                -- 4 Студент не закрыл сессию
                -- 5 Студент исключен
                -- 6 Студент закончил  степень
            */

        public virtual ICollection<Student> Students { get; set; }
    }
}

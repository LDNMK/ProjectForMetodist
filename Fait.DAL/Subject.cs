using System;
using System.Collections.Generic;

#nullable disable

namespace Fait.DAL
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }//ссылк ана учебный план
        public string SubName { get; set; }//название предмета
        public int SubHours { get; set; }// сколько часов
        public int Ects { get; set; }//кредитов ECTS
        public bool Monitoring { get; set; }//0 ЗАЧЕТ 1 КУРСОВАЯ
        public bool Task { get; set; }// 0 задания нет, 1 есть
        public byte Semester { get; set; }//семестр

        public virtual YearPlan Plan { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}

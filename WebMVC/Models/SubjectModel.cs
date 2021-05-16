using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SubjectModel
    {
        public string SubName { get; set; }//название предмета
        public int SubHours { get; set; }// сколько часов
        public int Ects { get; set; }//кредитов ECTS
        public bool Monitoring { get; set; }//0 ЗАЧЕТ 1 КУРСОВАЯ
        public bool Task { get; set; }// 0 задания нет, 1 есть
        public byte Semester { get; set; }//семестр
    }
}

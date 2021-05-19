using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class SubjectDTO
    {
        public string SubName { get; set; }//название предмета
        public string SubHoursAndETCS { get; set; }// сколько часов

        public Byte? AutumnTask { get; set; }// 0 задания нет, 1 есть
        public Byte? SpringTask { get; set; }
        public Byte? AutumnMonitoring { get; set; }
        public Byte? SpringMonitoring { get; set; }
        public string Faculty { get; set; }
    }
}

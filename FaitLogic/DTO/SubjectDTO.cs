using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class SubjectDTO
    {
        public string SubName { get; set; }//название предмета
        public string SubHoursAndETCS { get; set; }// сколько часов

        public bool? AutumnTask { get; set; }// 0 задания нет, 1 есть
        public bool? SpringTask { get; set; }
        public bool? AutumnMonitoring { get; set; }
        public bool? SpringMonitoring { get; set; }
        public string Faculty { get; set; }
    }
}

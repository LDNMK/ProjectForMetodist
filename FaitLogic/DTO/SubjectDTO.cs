using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class SubjectDTO
    {
        public string SubName { get; set; }//название предмета
        public string SubHoursAndETCS { get; set; }// сколько часов

        public byte? AutumnTask { get; set; }// 0 задания нет, 1 есть
        public byte? SpringTask { get; set; }
        public byte? AutumnMonitoring { get; set; }
        public byte? SpringMonitoring { get; set; }
        public string Faculty { get; set; }
    }
}

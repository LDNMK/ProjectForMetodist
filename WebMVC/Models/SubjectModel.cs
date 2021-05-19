using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SubjectModel
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

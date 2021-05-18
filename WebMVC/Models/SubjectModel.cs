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
      
        public bool AutumnTask { get; set; }// 0 задания нет, 1 есть
        public bool SpringTask { get; set; }
        public bool AutumnMonitoing { get; set; }
        public bool SpringMonitoing { get; set; }


    }
}

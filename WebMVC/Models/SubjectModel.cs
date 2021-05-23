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
      
        public byte AutumnTask { get; set; } // 0 - отсутствует в этом семестре, 1 - задания нет, 2 - задания есть
        public byte SpringTask { get; set; }
        public byte AutumnMonitoring { get; set; }
        public byte SpringMonitoring { get; set; }
        public string Faculty { get; set; }
    }
}

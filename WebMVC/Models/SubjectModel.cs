using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SubjectModel
    {
        public int? Id { get; set; }
        
        public string Name { get; set; }
        
        public int Hours { get; set; }
        
        public int Ects { get; set; }
        
        public int? IndividualTaskFallType { get; set; }     // 0 - отсутствует в этом семестре, 1 - задания нет, 2 - задания есть
        
        public int? IndividualTaskSpringType { get; set; }
        
        public byte? ControlFallType { get; set; }
        
        public byte? ControlSpringType { get; set; }
        
        public string Department { get; set; }
    }
}

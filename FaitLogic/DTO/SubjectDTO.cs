using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Hours { get; set; }
        
        public int Ects { get; set; }
        
        public int IndividualTaskFallType { get; set; }
        
        public int IndividualTaskSpringType { get; set; }
        
        public byte ControlFallType { get; set; }
        
        public byte ControlSpringType { get; set; }
        
        public string Department { get; set; }
    }
}

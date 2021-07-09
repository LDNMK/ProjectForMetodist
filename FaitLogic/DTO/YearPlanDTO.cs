using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class YearPlanDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Year { get; set; }
        
        public ICollection<int> GroupIds { get; set; }              // Группы 
        
        public ICollection<SubjectDTO> SubjectInfo { get; set; }    // Предметы 
    }
}

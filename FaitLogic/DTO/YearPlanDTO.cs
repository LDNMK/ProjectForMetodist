using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class YearPlanDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<int> GroupIds { get; set; }              //группы 
        public ICollection<SubjectDTO> SubjectInfo { get; set; }  //предметы 
    }
}

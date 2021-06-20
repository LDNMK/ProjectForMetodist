using System.Collections.Generic;

namespace WebAPI.Models
{
    public class YearPlanModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<int> GroupIds { get; set; }              //группы 
        public ICollection<SubjectModel> SubjectInfo { get; set; }  //предметы     
    }
}

using System.Collections.Generic;

namespace WebAPI.Models
{
    public class YearPlanModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public ICollection<int> GroupIds { get; set; }              // Группы 
        
        public ICollection<SubjectModel> SubjectInfo { get; set; }  // Предметы     
    }
}

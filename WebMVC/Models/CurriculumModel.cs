using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CurriculumModel
    {
        public string PlanName { get; set; }//название

        //Where it is???
        public int PlanYear { get; set; }//год
        public int Course { get; set; }//курс 
        public string Groups { get; set; }//группы 
        public List<SubjectModel> SubjectInfo { get; set; }//предметы     
    }
}

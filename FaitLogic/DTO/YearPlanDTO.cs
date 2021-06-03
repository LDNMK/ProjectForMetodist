﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.DTO
{
    public class YearPlanDTO
    {
        public string PlanName { get; set; }//название
        public int PlanYear { get; set; }//год
        public int Course { get; set; }//курс 
        public string Groups { get; set; }//группы 
        public List<SubjectDTO> SubjectInfo { get; set; }//
    }
}
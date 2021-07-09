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
        public bool IsIndividualTaskExistFall { get; set; } // 0 - отсутствует в этом семестре, 1 - задания нет, 2 - задания есть
        public bool IsIndividualTaskExistSpring { get; set; }
        public byte ControlTypeFall { get; set; }
        public byte ControlTypeSpring { get; set; }
        public string Department { get; set; }
    }
}

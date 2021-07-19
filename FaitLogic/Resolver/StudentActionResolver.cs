﻿using FaitLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Resolver
{
    public class StudentActionResolver : IStudentActionResolver
    {
        public StudentActionEnum Resolve(StudentStateEnum sse)
        {
            return sse switch
            {
                StudentStateEnum.DefaultTransfer => StudentActionEnum.DefaultTransfer,
                StudentStateEnum.AcademicLeave => StudentActionEnum.AcademicLeave,
                StudentStateEnum.Expelled => StudentActionEnum.Recover,
                _ => default
            };
        }
    }
}
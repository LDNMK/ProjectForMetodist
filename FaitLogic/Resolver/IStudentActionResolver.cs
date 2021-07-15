using FaitLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Resolver
{
    interface IStudentActionResolver
    {
        StudentActionEnum Resolve(StudentStateEnum sse);
    }
}

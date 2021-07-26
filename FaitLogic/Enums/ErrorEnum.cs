using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FaitLogic.Enums
{
    public enum ErrorEnum
    {
        [Description("Такі дані про студента вже використовуються")]
        StudentDbUpdateFailed,
    }
}

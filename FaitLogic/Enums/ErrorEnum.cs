using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FaitLogic.Enums
{
    public enum ErrorEnum
    {
        [Description("Дані про студента вказані некоректно або вони вже використовуються")]
        StudentDbUpdateFailed,

        [Description("Такого навчального плану немає")]
        YearPlanNotExist,

        [Description("Така група вже існує")]
        GroupAlreadyExist,
    }
}

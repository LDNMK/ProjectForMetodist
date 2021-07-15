using System;
using System.Collections.Generic;
using System.Text;

namespace FaitLogic.Enums
{
    public enum StudentActionEnum
    {
        DefaultTransfer = 1,    // Перевод с группой
        AcademicLeave = 2,      // Академ. отпуск
        LeaveForSecondYear = 3, // Оставить на второй год
        Dismiss = 4,            // Отчислить
        Recover = 5,            // Восстановить
    }
}

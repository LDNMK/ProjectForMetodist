using System;
using System.Collections.Generic;
using System.Text;

namespace Fait.LogicObjects.Enums
{
    public enum StudentStateEnum
    {
        DefaultTransfer = 1,//Перевод с группой
        AcademicLeave = 2,// Студент в академ отпуске
        TransferInAnotherGroup = 3,//Студент переходит в другую группу
        NotClosedSession = 4,//Студент не закрыл сессию
        StudentExpelled = 5,//Студент исключен
        StudentGradueted = 6//Студент закончил  степень

    }
}

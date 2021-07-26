using EnumsNET;
using FaitLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper
{
    public static class ValidationHelper
    {
        public static string GetErrorDescription(ErrorEnum error)
        {
            return error.AsString(EnumFormat.Description);
        }
    }
}

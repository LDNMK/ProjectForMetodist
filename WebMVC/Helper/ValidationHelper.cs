using EnumsNET;
using FaitLogic.Enums;
using WebAPI.Helper.ValidationResponse.Enum;

namespace WebAPI.Helper
{
    public static class ValidationHelper
    {
        //public static string GetEnumDescription(ErrorEnum error)
        //{
        //    return error.AsString(EnumFormat.Description);
        //}

        //public static string GetEnumDescription(WarningEnum error)
        //{
        //    return error.AsString(EnumFormat.Description);
        //}

        //public static string GetEnumDescription(SuccessEnum error)
        //{
        //    return error.AsString(EnumFormat.Description);
        //}
        public static string GetEnumDescription<T>(T message)
            where T : struct, System.Enum
        {
            return message.AsString(EnumFormat.Description);
        }
    }
}

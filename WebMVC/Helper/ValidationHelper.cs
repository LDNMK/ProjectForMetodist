using EnumsNET;
using System;
using System.Text.Json;

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
            where T : struct, Enum
        {
            return message.AsString(EnumFormat.Description);
        }

        public static string GetSerializedErrorInfo<T>(T exception)
            where T : Exception
        {
            return JsonSerializer.Serialize($"{exception.Message}\n{exception.StackTrace}");
        }
    }
}

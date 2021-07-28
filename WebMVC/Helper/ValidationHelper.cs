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
        public static string GetEnumDescription(ErrorEnum error)
        {
            return error.AsString(EnumFormat.Description);
        }

        public static string GetEnumDescription(WarningEnum error)
        {
            return error.AsString(EnumFormat.Description);
        }

        public static string GetEnumDescription(SuccessEnum error)
        {
            return error.AsString(EnumFormat.Description);
        }
    }

    public abstract class ResponseModel
    {
        public string NotificationType { get; set; }

        public string NotificationText { get; set; }
    }

    public class ErrorResponseModel : ResponseModel
    {
        public ErrorResponseModel()
        {
            NotificationType = "error";
        }
    }

    public class WarningResponseModel : ResponseModel
    {
        public WarningResponseModel()
        {
            NotificationType = "warning";
        }
    }

    public class SuccessResponseModel : ResponseModel
    {
        public object Data { get; set; }

        public SuccessResponseModel()
        {
            NotificationType = "success";
        }
    }
}

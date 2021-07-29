using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ResponseModel
{
    public class ErrorResponseModel : IResponseModel
    {
        public string NotificationType { get; set; } = "error";

        public string NotificationText { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ResponseModel
{
    public class WarningResponseModel : IResponseModel
    {
        public string NotificationType { get; set; } = "warning";

        public string NotificationText { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ResponseModel
{
    public interface IResponseModel
    {
        string NotificationType { get; set; }

        string NotificationText { get; set; }
    }
}

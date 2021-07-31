using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ValidationResponse.Interface
{
    public interface IResponseModel
    {
        string NotificationType { get; set; }

        string NotificationText { get; set; }
    }
}

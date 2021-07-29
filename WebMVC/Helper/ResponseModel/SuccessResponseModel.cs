using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ResponseModel
{
    public class SuccessResponseModel : IResponseModelData
    {
        public object Data { get; set; }

        public string NotificationType { get; set; } = "success";
        
        public string NotificationText { get; set; }
    }
}

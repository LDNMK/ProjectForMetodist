using WebAPI.Helper.ValidationResponse.Interface;

namespace WebAPI.Helper.ValidationResponse
{
    public class ValidationResponseMessage: IResponseModel
    {
        public string NotificationType { get; set; }

        public string NotificationText { get; set; }

        public string ExceptionJSON { get; set; }
    }
}

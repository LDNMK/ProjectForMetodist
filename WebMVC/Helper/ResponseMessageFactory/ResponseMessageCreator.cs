using WebAPI.Helper.ValidationResponse;
using WebAPI.Helper.ValidationResponse.Enum;
using WebAPI.Helper.ValidationResponse.Interface;

namespace WebAPI.Helper.ResponseMessageFactory
{
    public static class ResponseMessageCreator
    {
        public static IResponseModel GetMessage<T>(T messageEnum, string exceptionJSON = "ok")
            where T: struct, System.Enum
        {
            return new ValidationResponseMessage {
                 NotificationType = messageEnum.GetType().Name,
                 NotificationText = ValidationHelper.GetEnumDescription(messageEnum),
                 ExceptionJSON = exceptionJSON
            };
        }
    }
}

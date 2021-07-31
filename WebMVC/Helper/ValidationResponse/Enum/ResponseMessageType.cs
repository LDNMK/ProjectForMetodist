using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebAPI.Helper.ValidationResponse.Enum
{
    public enum ResponseMessageType
    {
        [Description("success")]
        Success = 1,

        [Description("warning")]
        Warning = 2,

        [Description("error")]
        Error = 3
    }
}

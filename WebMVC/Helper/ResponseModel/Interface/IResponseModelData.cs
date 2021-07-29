using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helper.ResponseModel
{
    interface IResponseModelData : IResponseModel
    {
        public object Data { get; set; }
    }
}

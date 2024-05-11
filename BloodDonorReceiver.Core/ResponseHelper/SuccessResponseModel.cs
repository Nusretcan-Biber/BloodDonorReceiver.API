using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Core.ResponseHelper
{
    public class SuccessResponseModel<T> : BaseResponseModel where T : class
    {
        public SuccessResponseModel() : this("Transaction Success", HttpStatusCode.OK, null)
        {

        }

        public SuccessResponseModel(HttpStatusCode statusCode) : this("Transaction Success", statusCode, null)
        {

        }

        public SuccessResponseModel(T responseData) : this("Transaction Success", HttpStatusCode.OK, responseData)
        {

        }

        public SuccessResponseModel(HttpStatusCode statusCode, T responseData) : this("Transaction Success", statusCode, responseData)
        {

        }

        public SuccessResponseModel(string message, T responseData) : this(message, HttpStatusCode.OK, responseData)
        {

        }

        public SuccessResponseModel(string message, HttpStatusCode statusCode) : this(message, statusCode, null)
        {

        }

        public SuccessResponseModel(string message) : this(message, HttpStatusCode.OK, null)
        {

        }

        public SuccessResponseModel(string message, HttpStatusCode statusCode, T responseData)
        {
            this.Message = message;
            this.Status = true;
            this.StatusCode = statusCode;
            this.ResponseData = responseData;
        }

        public T ResponseData { get; set; }

    }
}

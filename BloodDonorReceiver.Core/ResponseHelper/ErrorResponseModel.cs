using System.Net;

namespace BloodDonorReceiver.Core.ResponseHelper
{
    public class ErrorResponseModel : BaseResponseModel
    {
        public ErrorResponseModel() : this("Transaction Failed", HttpStatusCode.BadRequest)
        {

        }

        public ErrorResponseModel(HttpStatusCode statusCode) : this("Transaction Failed", statusCode)
        {

        }

        public ErrorResponseModel(string message) : this(message, HttpStatusCode.BadRequest)
        {

        }

        public ErrorResponseModel(string message, HttpStatusCode statusCode)
        {
            this.Message = message;
            this.Status = false;
            this.StatusCode = statusCode;
        }
    }

}

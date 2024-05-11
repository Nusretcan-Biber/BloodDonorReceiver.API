using System.Net;

namespace BloodDonorReceiver.Core.ResponseHelper
{
    public interface IBaseResponseModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Status { get; set; }

    }
}

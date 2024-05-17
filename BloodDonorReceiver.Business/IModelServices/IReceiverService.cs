using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface IReceiverService
    {
        public BaseResponseModel CreateReceiver(ReceiverDto receiverDto);
        public BaseResponseModel UpdateReceiver(UpdateReceiverDto updateReceiverDto);
        public BaseResponseModel DeleteReceiver(string Email, string phoneNumber);
    }
}

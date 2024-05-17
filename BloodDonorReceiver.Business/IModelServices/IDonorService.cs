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
    public interface IDonorService
    {
        public BaseResponseModel CreateDonor(DonorDto donorDto);
        public BaseResponseModel GetDonorByCity(string City);
        public BaseResponseModel GetDonorByBloodType(BloodTypeEnum bloodType);
        public BaseResponseModel UpdateDonor(UpdateDonorDto donorDto);
        public BaseResponseModel DeleteDonor(string Email, string phoneNumber);
    }
}

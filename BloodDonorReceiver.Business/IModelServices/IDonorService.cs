using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface IDonorService
    {
        public BaseResponseModel CreateDonor(DonorDto donorDto);
        public BaseResponseModel GetDonorByCity(string City);
        public BaseResponseModel GetDonorByBloodType(BloodTypeEnum bloodType);
        public BaseResponseModel UpdateDonor(UpdateDonorDto donorDto);
        public BaseResponseModel DeleteDonor(string tcno);
    }
}

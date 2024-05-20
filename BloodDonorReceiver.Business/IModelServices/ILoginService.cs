using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface ILoginService
    {
        public BaseResponseModel Login(LoginUserDto loginParams);
    }
}

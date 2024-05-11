using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface IUserService
    {
        public BaseResponseModel CreateUser(UserDto user);
        public BaseResponseModel UpdateUser(UpdateUserDto user);
        public BaseResponseModel DeleteUser(string TCKNO);
        public BaseResponseModel GetUserByTCKNO(string TCKNO);
    }
}

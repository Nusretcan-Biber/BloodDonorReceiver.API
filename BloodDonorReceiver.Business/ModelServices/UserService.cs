using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.AutoMapper;
using BloodDonorReceiver.Utils.Extensions;
using BloodDonorReceiver.Utils.UnitOfWorks;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class UserService : IUserService
    {
        public BaseResponseModel CreateUser(UserDto user)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistUser = uow.GetRepository<UserModel>().Any(x=> x.TCNO.Equals(user.TCNO));
                if (isExistUser)
                    return new ErrorResponseModel("Böyle bir kullanıcı zaten bulunmaktadır.");
                var createdUser = MappingProfile<UserDto, UserModel>.Instance.Mapper.Map<UserModel>(user);
                uow.GetRepository<UserModel>().Add(createdUser);
                if(uow.SaveChanges()<0)
                    return new ErrorResponseModel("Kullanıcı kayıt edilemedi.");
                return new SuccessResponseModel<UserModel>("Kullanıcı kaydı başarılı.");

            }
        }

        public BaseResponseModel DeleteUser(string TCKNO)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistUser = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(TCKNO));
                if (isExistUser ==null)
                    return new ErrorResponseModel("Böyle bir kullanıcı bulunamamaktadır.");
                uow.GetRepository<UserModel>().Delete(isExistUser);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Kullanıcı silinemedi.İşlem başarısız");
                return new SuccessResponseModel<UserModel>("Kullanıcı silindi. İşlem Başarılı");

            }
        }

        public BaseResponseModel GetUserByTCKNO(string TCKNO)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistUser = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(TCKNO));
                if (isExistUser == null)
                    return new ErrorResponseModel("Böyle bir kullanıcı bulunamamaktadır.");
                return new SuccessResponseModel<UserModel>("Kullanıcı bulundu. İşlem Başarılı", isExistUser);

            }
        }

        public BaseResponseModel UpdateUser(UpdateUserDto user)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistUser = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(user.TCNO));
                if (isExistUser == null)
                    return new ErrorResponseModel("Böyle bir kullanıcı bulunmamaktadır.");
                var updatedUser = CheckNullValuesAndMappingForUpdateUserExtension.CheckNullValuesAndMapping(user, isExistUser);
                
                uow.GetRepository<UserModel>().Update(updatedUser);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Kullanıcı güncellenemedi. İşlem başarısız");
                return new SuccessResponseModel<UserModel>("Kullanıcı güncellendi. İşlem başarılı");

            }
        }


        
    }
}

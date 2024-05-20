using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.AutoMapper;
using BloodDonorReceiver.Utils.Extensions;
using BloodDonorReceiver.Utils.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class ReceiverService : IReceiverService
    {
        private IUserService _userService = new UserService();
        public BaseResponseModel CreateReceiver(ReceiverDto receiverDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistReceiver = uow.GetRepository<ReceiverModel>().Any(x => x.TCNO.Equals(receiverDto.TCNO));
                if (isExistReceiver)
                    return new ErrorResponseModel("Böyle bir kullanıcı zaten bulunmaktadır.");
                var createdReceiver = MappingProfile<ReceiverDto, ReceiverModel>.Instance.Mapper.Map<ReceiverModel  >(receiverDto);
                var user = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(receiverDto.TCNO));
                if (user == null)
                {
                    var userDto = new UserDto()
                    {
                        Birthday = receiverDto.Birthday,
                        Name = receiverDto.Name,
                        Email = receiverDto.Email,
                        PhoneNumber = receiverDto.PhoneNumber,
                        Surname = receiverDto.Surname,
                        Password = receiverDto.Name + "." + receiverDto.Surname,
                        ConfirmPassword = receiverDto.Name + "." + receiverDto.Surname,
                        TCNO = receiverDto.TCNO
                    };
                    var result = _userService.CreateUser(userDto);
                    if (result.StatusCode != System.Net.HttpStatusCode.OK)
                        return new ErrorResponseModel();
                    user = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(receiverDto.TCNO));
                }
                createdReceiver.UserGuid = user.Guid;
                uow.GetRepository<ReceiverModel>().Add(createdReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı kayıt edilemedi");
                return new SuccessResponseModel<DonorModel>("Alıcı kaydı başarılı.");
            }
        }

        public BaseResponseModel DeleteReceiver(string tcno)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistReceiver = uow.GetRepository<ReceiverModel>().Get(x => x.TCNO.Equals(tcno));
                if (isExistReceiver == null)
                    return new ErrorResponseModel("Böyle bir alıcı bulunamamaktadır.");
                uow.GetRepository<ReceiverModel>().Delete(isExistReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı silinemedi.İşlem başarısız");
                return new SuccessResponseModel<ReceiverModel>("Alıcı silindi. İşlem Başarılı");

            }
        }

        public BaseResponseModel GetReceiverByBloodType(BloodTypeEnum bloodType)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonorList = uow.GetRepository<ReceiverModel>().GetAll(x => x.BloodType == bloodType).AsNoTracking().ToList();
                if (isExistDonorList.Count == 0)
                    return new ErrorResponseModel("Böyle bir kan grubuna sahip alıcı yok");
                return new SuccessResponseModel<List<ReceiverModel>>("Alıcı bulundu. İşlem başarılı", isExistDonorList);

            }
        }

        public BaseResponseModel GetReceiverByCity(int cityId)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonorList = uow.GetRepository<ReceiverModel>().GetAll(x => x.CityId == cityId).AsNoTracking().ToList();
                if (isExistDonorList.Count == 0)
                    return new ErrorResponseModel("Bu şehirde herhangi bir alıcı bulunmamaktadır");
                return new SuccessResponseModel<List<ReceiverModel>>("Alıcılar bulundu. İşlem başarılı", isExistDonorList);

            }
        }

        public BaseResponseModel UpdateReceiver(UpdateReceiverDto updateReceiverDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistReceiver = uow.GetRepository<ReceiverModel>().Get(x => x.TCNO.Equals(updateReceiverDto.TCNO));
                if (isExistReceiver == null)
                    return new ErrorResponseModel("Böyle bir kan alıcısı bulunmamaktadır");
                var updatedReceiver = CheckNullValuesAndMappingForUpdateUserExtension.CheckNullValuesAndMapping(updateReceiverDto, isExistReceiver);
                updatedReceiver.IsUpdated = true;
                updatedReceiver.UpdatedDate = DateTime.UtcNow;
                uow.GetRepository<ReceiverModel>().Update(updatedReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı güncellenemedi. İşlem başarısız");
                return new SuccessResponseModel<ReceiverModel>("Alıcı güncellendi. İşlem başarılı");
            }
        }


    }
}

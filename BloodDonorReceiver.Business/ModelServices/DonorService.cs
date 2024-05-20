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
    public class DonorService : IDonorService
    {
        private IUserService _userService = new UserService();
        public BaseResponseModel CreateDonor(DonorDto donorDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var donor = uow.GetRepository<DonorModel>().Get(x => x.TCNO.Equals(donorDto.TCNO));
                if (donor == null)
                {
                    var createdDonor = MappingProfile<DonorDto, DonorModel>.Instance.Mapper.Map<DonorModel>(donorDto);
                    var user = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(donorDto.TCNO));

                    if (user == null)
                    {
                        var userDto = new UserDto()
                        {
                            Birthday = donorDto.Birthday,
                            Name = donorDto.Name,
                            Email = donorDto.Email,
                            PhoneNumber = donorDto.PhoneNumber,
                            Surname = donorDto.Surname,
                            Password = donorDto.Name + "." + donorDto.Surname,
                            ConfirmPassword = donorDto.Name + "." + donorDto.Surname,
                            TCNO = donorDto.TCNO
                        };
                        var result = _userService.CreateUser(userDto);
                        if (result.StatusCode != System.Net.HttpStatusCode.OK)
                            return new ErrorResponseModel();
                        user = uow.GetRepository<UserModel>().Get(x => x.TCNO.Equals(donorDto.TCNO));
                    }
                    createdDonor.UserGuid = user.Guid;

                    DonorsCitiesModel donorsCitiesModel = new DonorsCitiesModel()
                    {
                        Guid = Guid.NewGuid(),
                        CitysId = createdDonor.CityId,
                        DonorsGuid = createdDonor.Guid
                    };

                    uow.GetRepository<DonorModel>().Add(createdDonor);
                    uow.GetRepository<DonorsCitiesModel>().Add(donorsCitiesModel);

                    if (uow.SaveChanges() < 0)
                        return new ErrorResponseModel("Bağışçı kayıt edilemedi");
                }

                return new SuccessResponseModel<DonorModel>("Bağışçı kaydı başarılı.");
            }
        }

        public BaseResponseModel GetDonorByBloodType(BloodTypeEnum bloodType)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonorList = uow.GetRepository<DonorModel>().GetAll(x => x.BloodType == bloodType).AsNoTracking().ToList();
                if (isExistDonorList.Count == 0)
                    return new ErrorResponseModel("Böyle bir kan grubuna sahip donör yok");
                return new SuccessResponseModel<List<DonorModel>>("Donör bulundu. İşlem başarılı", isExistDonorList);

            }
        }

        public BaseResponseModel GetDonorByCity(int cityId)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonorList = uow.GetRepository<DonorModel>().GetAll(x => x.CityId == cityId).AsNoTracking().ToList();
                if (isExistDonorList.Count == 0)
                    return new ErrorResponseModel("Bu şehirde herhangi bir bağışçı bulunmamaktadır");
                return new SuccessResponseModel<List<DonorModel>>("Bağışçılar bulundu. İşlem başarılı", isExistDonorList);

            }
        }

        public BaseResponseModel UpdateDonor(UpdateDonorDto donorDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonor = uow.GetRepository<DonorModel>().Get(x => x.TCNO.Equals(donorDto.TCNO));
                if (isExistDonor == null)
                    return new ErrorResponseModel("Böyle bir kan bağışçısı bulunmamaktadır");
                var updatedDonor = CheckNullValuesAndMappingExtension.CheckNullValuesAndMapping(donorDto, isExistDonor);
                updatedDonor.IsUpdated = true;
                updatedDonor.UpdatedDate = DateTime.UtcNow;
                uow.GetRepository<DonorModel>().Update(updatedDonor);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Bağışçı güncellenemedi. İşlem başarısız");
                return new SuccessResponseModel<DonorModel>("Bağışçı güncellendi. İşlem başarılı");
            }
        }

        public BaseResponseModel DeleteDonor(string tcno)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistDonor = uow.GetRepository<DonorModel>().Get(x => x.TCNO.Equals(tcno));
                if (isExistDonor == null)
                    return new ErrorResponseModel("Böyle bir bağışçı bulunamamaktadır.");
                uow.GetRepository<DonorModel>().Delete(isExistDonor);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("bağışçı silinemedi.İşlem başarısız");
                return new SuccessResponseModel<DonorModel>("bağışçı silindi. İşlem Başarılı");

            }
        }
    }
}

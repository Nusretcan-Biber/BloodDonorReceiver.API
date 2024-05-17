using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.AutoMapper;
using BloodDonorReceiver.Utils.Extensions;
using BloodDonorReceiver.Utils.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class ReceiverService : IReceiverService
    {
        public BaseResponseModel CreateReceiver(ReceiverDto receiverDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var createdReceiver = MappingProfile<ReceiverDto, ReceiverModel>.Instance.Mapper.Map<ReceiverModel  >(receiverDto);
                uow.GetRepository<ReceiverModel>().Add(createdReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı kayıt edilemedi");
                return new SuccessResponseModel<DonorModel>("Alıcı kaydı başarılı.");
            }
        }

        public BaseResponseModel DeleteReceiver(string Email, string phoneNumber)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistReceiver = uow.GetRepository<ReceiverModel>().Get(x => x.Email.Equals(Email) && x.PhoneNumber.Equals(phoneNumber));
                if (isExistReceiver == null)
                    return new ErrorResponseModel("Böyle bir alıcı bulunamamaktadır.");
                uow.GetRepository<ReceiverModel>().Delete(isExistReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı silinemedi.İşlem başarısız");
                return new SuccessResponseModel<ReceiverModel>("Alıcı silindi. İşlem Başarılı");

            }
        }

        public BaseResponseModel UpdateReceiver(UpdateReceiverDto updateReceiverDto)
        {
            

            using (var uow = new UnitOfWork<MasterContext>())
            {
                var isExistReceiver = uow.GetRepository<ReceiverModel>().Get(x => x.Email.Equals(updateReceiverDto.Email) && x.PhoneNumber.Equals(updateReceiverDto.PhoneNumber));
                if (isExistReceiver == null)
                    return new ErrorResponseModel("Böyle bir kan alıcısı bulunmamaktadır");
                var updatedReceiver = CheckNullValuesAndMappingForUpdateUserExtension.CheckNullValuesAndMapping(updateReceiverDto, isExistReceiver);
                uow.GetRepository<ReceiverModel>().Update(updatedReceiver);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Alıcı güncellenemedi. İşlem başarısız");
                return new SuccessResponseModel<ReceiverModel>("Alıcı güncellendi. İşlem başarılı");
            }
        }
    }
}

using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;
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
    public class DonorService : IDonorService
    {
        public BaseResponseModel CreateDonor(DonorDto donorDto)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var createdDonor = MappingProfile<DonorDto,DonorModel>.Instance.Mapper.Map<DonorModel>(donorDto);
                uow.GetRepository<DonorModel>().Add(createdDonor);
                if (uow.SaveChanges() < 0)
                    return new ErrorResponseModel("Kullanıcı kayıt edilemedi");
                return new SuccessResponseModel<DonorModel>("Kullanıcı kaydı başarılı.");
            }
        }

        public BaseResponseModel GetDonorByBloodType(BloodTypeEnum bloodType)
        {
            throw new NotImplementedException();
            //using (var uow = new UnitOfWork<MasterContext>())
            //{
            //    var isExistDonor = uow.GetRepository<DonorModel>().GetAll(x => x.BloodType);
            //    if (isExistDonor == null)
            //        return new ErrorResponseModel("Böyle bir kan grubuna sahip donör yok");
            //    return new SuccessResponseModel<DonorModel>("Donör bulundu. İşlem başarılı");

            //}
        }

        public BaseResponseModel GetDonorByCity(string City)
        {
            throw new NotImplementedException();
        }
    }
}

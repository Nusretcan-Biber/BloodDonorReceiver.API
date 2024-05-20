using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.UnitOfWorks;
using System.Net;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class LoginService : ILoginService
    {
        public BaseResponseModel Login(LoginUserDto loginParams)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                loginParams.Password = loginParams.Password;
                var result = uow.GetRepository<UserModel>().Get(x => x.Email.Equals(loginParams.Email) && x.Password.Equals(loginParams.Password));
                if (result == null)
                    return new ErrorResponseModel("Kullanıcı bilgileri hatalı. Bilgilerinizi kontrol edip tekrar deneyiniz", HttpStatusCode.Unauthorized);
                else
                    return new SuccessResponseModel<string>("Kullanıcı bilgileri doğrulandı. Giriş Başarılı");
            }
        }
    }
}

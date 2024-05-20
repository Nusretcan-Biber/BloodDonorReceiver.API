using BloodDonorReceiver.Core.ResponseHelper;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BloodDonorReceiver.Utils.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class AuthenticationAttribute : Attribute, IAsyncActionFilter
    {

        //Headers olarak hiç authorization verilmemişse istekte buraya gelir ve hata döner
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            // catch ve doğrulayamama durumunda set edilir.
            var defaultErrorResult = new ContentResult()
            {
                StatusCode = 401,
                Content = JsonConvert.SerializeObject(new BaseResponseModel
                {
                    Message = "Authentication işlemi başarısız",
                    StatusCode = HttpStatusCode.Unauthorized,
                    Status = false
                })
            };

            try
            {
                if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
                {
                    context.Result = defaultErrorResult;
                    return;
                }
                //Authorization verilmiş. Verilen basic auth doğru mu değil mi kontrolü sağlanır.
                //Genel olarak süreç : 
                //Yapısı: Basic email:password
                //NOT : email:password bilgisi base64 formatında iletilecek SAP'den servise
                string[] authParts = authorizationHeader.FirstOrDefault().ToString().Split(' ');
                var mailAndPass = GetMailAndPassFromAuth(authParts);
                bool isValid = DatabaseValidation(mailAndPass[0], mailAndPass[1]);
                if (!isValid)
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = JsonConvert.SerializeObject(new BaseResponseModel
                        {
                            Message = "Authentication işlemi başarısız",
                            StatusCode = HttpStatusCode.Unauthorized,
                            Status = false
                        })
                    };
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = defaultErrorResult;
                return;
            }
            await next();
        }

        /// <summary>
        /// base64 formatında gelen veriyi stringe çeviren metod
        /// </summary>
        /// <param name="authParts">base64 formatınnda gelen data</param>
        /// <returns></returns>
        public string[] GetMailAndPassFromAuth(string[] authParts)
        {
            string base64Credentials = authParts[1];
            byte[] credentialBytes = Convert.FromBase64String(base64Credentials);
            string credentials = Encoding.UTF8.GetString(credentialBytes);
            string[] credentialParts = credentials.Split(':');
            return credentialParts;
        }

        /// <summary>
        /// veritabanına sorgu atar. Eğer öyle bir kullanıcı varsa true yoksa false döner
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool DatabaseValidation(string email, string password)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var authInformation = uow.GetRepository<UserModel>().Get(x => x.Email.Equals(email) && x.Password.Equals(password));
                if (authInformation != null)
                    return true;
                return false;
            }
        }
    }
}

using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using BloodDonorReceiver.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        ILoginService _loginService = new LoginService();

        [HttpPost(nameof(Login))]
        public IActionResult Login(LoginUserDto loginUser)
        {
            var result = _loginService.Login(loginUser);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

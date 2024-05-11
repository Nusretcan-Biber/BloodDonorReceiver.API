using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using BloodDonorReceiver.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService = new UserService();

        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser(UserDto user)
        {
            var result = _userService.CreateUser(user);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut(nameof(UpdateUser))]
        public IActionResult UpdateUser(UpdateUserDto user)
        {
            var result = _userService.UpdateUser(user);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(string TCNO)
        {
            var result = _userService.DeleteUser(TCNO);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetUserByTCNO))]
        public IActionResult GetUserByTCNO(string TCNO)
        {
            var result = _userService.GetUserByTCKNO(TCNO);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

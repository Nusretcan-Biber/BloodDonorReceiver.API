using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using BloodDonorReceiver.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private IDonorService _donorService = new DonorService();

        [HttpPost(nameof(CreateDonor))]
        public IActionResult CreateDonor(DonorDto donorDto)
        {
            var result = _donorService.CreateDonor(donorDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut(nameof(UpdateUser))]
        public IActionResult UpdateUser(UpdateDonorDto updateDonorDto)
        {
            var result = _donorService.UpdateDonor(updateDonorDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(string Email, string phoneNumber)
        {
            var result = _donorService.DeleteDonor(Email,phoneNumber);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

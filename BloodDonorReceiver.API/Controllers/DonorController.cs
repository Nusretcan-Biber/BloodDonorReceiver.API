using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;
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

        [HttpPut(nameof(UpdateDonor))]
        public IActionResult UpdateDonor([FromQuery]UpdateDonorDto updateDonorDto)
        {
            var result = _donorService.UpdateDonor(updateDonorDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteDonor))]
        public IActionResult DeleteDonor(string tcno)
        {
            var result = _donorService.DeleteDonor(tcno);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetDonorByBloodType))]
        public IActionResult GetDonorByBloodType(BloodTypeEnum bloodType)
        {
            var result = _donorService.GetDonorByBloodType(bloodType);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetDonorByCity))]
        public IActionResult GetDonorByCity(int cityId)
        {
            var result = _donorService.GetDonorByCity(cityId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

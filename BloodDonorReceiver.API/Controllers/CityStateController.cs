using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityStateController : ControllerBase
    {
        ICityAndStateService _cityStateService = new CityAndStateService();

        [HttpGet(nameof(GetAllCities))]
        public IActionResult GetAllCities()
        {
            var result = _cityStateService.GetAllCities();
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpGet(nameof(GetAllStates))]
        public IActionResult GetAllStates(int cityId)
        {
            var result = _cityStateService.GetAllCitysStates(cityId);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

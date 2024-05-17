using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodCenterController : ControllerBase
    {
        IBloodCenterService _cityStateService = new BloodCenterService();

        [HttpGet(nameof(GetAllBloodCenters))]
        public IActionResult GetAllBloodCenters()
        {
            var result = _cityStateService.GetAllBloodCenters();
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpGet(nameof(GetBloodCenterByCityAndStateId))]
        public IActionResult GetBloodCenterByCityAndStateId(int cityId, int stateId)
        {
            var result = _cityStateService.GetBloodCenterByCityAndStateId(cityId,stateId);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpGet(nameof(GetBloodCenterByStateId))]
        public IActionResult GetBloodCenterByStateId(int stateId)
        {
            var result = _cityStateService.GetBloodCenterByStateId(stateId);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpGet(nameof(GetBloodCenterByCityId))]
        public IActionResult GetBloodCenterByCityId(int cityId)
        {
            var result = _cityStateService.GetBloodCenterByCityId(cityId);
            if (result == null)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

﻿using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Business.ModelServices;
using BloodDonorReceiver.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorReceiver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private IReceiverService _receiverService = new ReceiverService();

        [HttpPost(nameof(CreateReceiver))]
        public IActionResult CreateReceiver(ReceiverDto receiverDto)
        {
            var result = _receiverService.CreateReceiver(receiverDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut(nameof(UpdateReceiver))]
        public IActionResult UpdateReceiver(UpdateReceiverDto updateReceiverDto)
        {
            var result = _receiverService.UpdateReceiver(updateReceiverDto);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(string Email, string phoneNumber)
        {
            var result = _receiverService.DeleteReceiver(Email, phoneNumber);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

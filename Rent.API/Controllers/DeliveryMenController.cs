using Microsoft.AspNetCore.Mvc;
using Rent.API.Abstractions.Controllers;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.DTOs.DeliveryMen;
using Rent.Infra.IoC.Entities.DeliveryMen;

namespace Rent.API.Controllers
{
    public class DeliveryMenController : RentController
    {
        private readonly IRegisterDeliveryManAppService _registerDeliveryManAppService;
        private readonly IUpdateCNHAppService _updateCNHAppService;

        public DeliveryMenController(IRegisterDeliveryManAppService registerDeliveryManAppService, IUpdateCNHAppService updateCNHAppService)
        {
            _registerDeliveryManAppService = registerDeliveryManAppService;
            _updateCNHAppService = updateCNHAppService;
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterDeliveryManAsync([FromBody] RegisterDeliveryManDTO dto)
        {
            var result = await _registerDeliveryManAppService.RegisterDeliveryManAsync(dto);

            if (_registerDeliveryManAppService.Invalid)
                return BadRequest(_registerDeliveryManAppService.Alerts);

            return Ok(result);
        }

        [HttpPut("{deliveryMenId}/update-cnh")]
        public async Task<IActionResult> UpdateCNHAsync([FromRoute] Guid deliveryMenId, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                await _updateCNHAppService.UpdateCNHAsync(deliveryMenId, fileBytes);

                if (_updateCNHAppService.Invalid)
                    return BadRequest(_updateCNHAppService.Alerts);

                return Ok();

            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

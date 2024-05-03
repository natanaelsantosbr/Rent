using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Abstractions.Controllers;
using Rent.API.DTOs;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.DTOs.DeliveryMen;

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
        [AllowAnonymous]
        public async Task<IActionResult> RegisterDeliveryManAsync([FromForm] CreateRegisterDeliveryManDTO model)
        {
            var dto = new RegisterDeliveryManDTO(
                model.Name,
                model.Email,
                model.Password,
                model.CNPJ,
                model.BirthDate,
                model.CNH,
                model.TypeCNH,
                model.ConvertFormFileToByteArray(model.File));

            var result = await _registerDeliveryManAppService.RegisterDeliveryManAsync(dto);

            if (_registerDeliveryManAppService.Invalid)
                return BadRequest(_registerDeliveryManAppService.Alerts);

            return Ok(result);
        }

        [HttpPut("{deliveryMenId}/update-cnh")]
        public async Task<IActionResult> UpdateCNHAsync([FromRoute] Guid deliveryMenId, [FromForm] CreateFileDTO dto)
        {
            if (dto == null || dto.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                await _updateCNHAppService.UpdateCNHAsync(dto.ConvertFormFileToByteArray(dto.File));

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

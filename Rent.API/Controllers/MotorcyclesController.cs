using Microsoft.AspNetCore.Mvc;
using Rent.API.Abstractions.Controllers;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.DTOs.Motorcycles;

namespace Rent.API.Controllers
{
    public class MotorcyclesController : RentController
    {
        private readonly IAddMotorcycleAppService _addMotorcycleAppService;
        private readonly IGetMotorcycleAppService _getMotorcycleAppService;
        private readonly IRemoveMotorcycleAppService _removeMotorcycleAppService;
        private readonly IUpdateLicensePlateAppService _updateLicensePlateAppService;


        public MotorcyclesController(IAddMotorcycleAppService addMotorcycleAppService, IGetMotorcycleAppService getMotorcycleAppService, IRemoveMotorcycleAppService removeMotorcycleAppService, IUpdateLicensePlateAppService updateLicensePlateAppService)
        {
            _addMotorcycleAppService = addMotorcycleAppService;
            _getMotorcycleAppService = getMotorcycleAppService;
            _removeMotorcycleAppService = removeMotorcycleAppService;
            _updateLicensePlateAppService = updateLicensePlateAppService;
        }

        [HttpPost()]
        public async Task<IActionResult> AddMotorcycleAsync([FromBody] AddMotorcycleDTO dto)
        {
            await _addMotorcycleAppService.AddMotorcycleAsync(dto);

            if (_addMotorcycleAppService.Invalid)
                return BadRequest(_addMotorcycleAppService.Alerts);

            return Ok();
        }

        [HttpGet()]
        public IActionResult GetMotorcyclesAsync([FromQuery] string? licensePlate)
        {
            var result = _getMotorcycleAppService.GetMotorcycleByLicensePlateAsync(licensePlate);

            if (_getMotorcycleAppService.Invalid)
                return BadRequest(_getMotorcycleAppService.Alerts);

            return Ok(result);
        }

        [HttpDelete("{motorcycleId}")]
        public async Task<IActionResult> RemoveMotorcycleAsync([FromRoute] Guid motorcycleId)
        {
            await _removeMotorcycleAppService.RemoveAsync(motorcycleId);

            if (_removeMotorcycleAppService.Invalid)
                return BadRequest(_removeMotorcycleAppService.Alerts);

            return Ok();
        }

        [HttpPut("{motorcycleId}/update-license-plate")]
        public async Task<IActionResult> UpdateLicensePlateAsync([FromRoute] Guid motorcycleId, [FromBody] string licensePlate)
        {
            await _updateLicensePlateAppService.UpdateLicensePlateAppAsync(motorcycleId, licensePlate);

            if (_updateLicensePlateAppService.Invalid)
                return BadRequest(_updateLicensePlateAppService.Alerts);

            return Ok();
        }
    }
}

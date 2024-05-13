using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.Application.Abstractions.AppServices.MotorycleRentals;
using Rent.Application.DTOs.MotorycleRentals;

namespace Rent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "deliveryman,admin")]
    public class MotorycleRentalsController : ControllerBase
    {
        private readonly ICalculateReturnCostAppService _calculateReturnCostAppService;
        private readonly IMotorycleRentalAppService _motorycleRentalAppService;

        public MotorycleRentalsController(ICalculateReturnCostAppService calculateReturnCostAppService, IMotorycleRentalAppService motorycleRentalAppService)
        {
            _calculateReturnCostAppService = calculateReturnCostAppService;
            _motorycleRentalAppService = motorycleRentalAppService;
        }

        [HttpPost]
        public async Task<IActionResult> RentMotorcycleAsync([FromBody] MotorycleRentalDTO dto)
        {
            await _motorycleRentalAppService.RentMotorcycleAsync(dto);

            if (_motorycleRentalAppService.Invalid)
                return BadRequest(_motorycleRentalAppService.Alerts);

            return Ok();
        }


        [HttpGet("{rentalId}/calculate/{returnDate}")]
        public async Task<IActionResult> CalculateReturnCostAsync([FromRoute] Guid rentalId, [FromRoute] DateTime returnDate)
        {
            var result = await _calculateReturnCostAppService.CalculeReturnCostAsync(rentalId, returnDate);

            if (_calculateReturnCostAppService.Invalid)
                return BadRequest(_calculateReturnCostAppService.Alerts);

            return Ok(result);
        }

    }
}

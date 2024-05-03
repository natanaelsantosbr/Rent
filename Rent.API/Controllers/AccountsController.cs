using Microsoft.AspNetCore.Mvc;
using Rent.API.Abstractions.Controllers;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.Users;

namespace Rent.API.Controllers
{
    public class AccountsController : RentController
    {
        private readonly IRegisterUserAdminAppService _registerUserAdminAppService;

        public AccountsController(IRegisterUserAdminAppService registerUserAdminAppService)
        {
            _registerUserAdminAppService = registerUserAdminAppService;
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDTO dto)
        {
            await _registerUserAdminAppService.Register(dto);

            if (_registerUserAdminAppService.Invalid)
                return BadRequest(_registerUserAdminAppService.Alerts);

            return Ok();
        }
    }
}

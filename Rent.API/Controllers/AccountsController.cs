using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent.API.Abstractions.Controllers;
using Rent.API.DTOs;
using Rent.Application.Abstractions.AppServices.Accounts;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.Users;

namespace Rent.API.Controllers
{
    public class AccountsController : RentController
    {
        private readonly IRegisterUserAdminAppService _registerUserAdminAppService;
        private readonly IAuthenticateAppService _authenticateAppService;

        public AccountsController(IRegisterUserAdminAppService registerUserAdminAppService, IAuthenticateAppService authenticateAppService)
        {
            _registerUserAdminAppService = registerUserAdminAppService;
            _authenticateAppService = authenticateAppService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Post([FromBody] LoginDTO model)
        {
            var result = await _authenticateAppService.AuthenticateAsync(model.Email, model.Password);

            if (_authenticateAppService.Invalid)
                return BadRequest(_authenticateAppService.Alerts);

            return Ok(result);
        }

        [HttpPost("register-admin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDTO dto)
        {
            await _registerUserAdminAppService.RegisterAsync(dto);

            if (_registerUserAdminAppService.Invalid)
                return BadRequest(_registerUserAdminAppService.Alerts);

            return Ok();
        }        
    }
}

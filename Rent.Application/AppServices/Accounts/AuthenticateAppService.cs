using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Accounts;
using Rent.Application.DTOs.Accounts;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.AppServices.Accounts
{
    public class AuthenticateAppService : AppService, IAuthenticateAppService
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticateAppService(IAuthenticateService authenticateService, ITokenService tokenService, IUnitOfWork unitOfWork)
        {
            _authenticateService = authenticateService;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserTokenDTO> Authenticate(string email, string password)
        {
            var result = await _authenticateService.Authenticate(email, password);

            if (!result)
            {
                Alert("invalid email or password");
                return null;
            }

            var userRepository = _unitOfWork.ObterRepository<User>();

            var user = userRepository.Consultar().FirstOrDefault(a => a.Email == email);

            if (user == null)
            {
                Alert("user not found");
                return null;
            }

            var token = _tokenService.Create(user);

            return new UserTokenDTO
            {
                Token = token
            };
        }
    }
}

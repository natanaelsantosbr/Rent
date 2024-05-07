using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.Users;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;

namespace Rent.Application.AppServices.Users
{
    public class RegisterUserAdminAppService : AppService, IRegisterUserAdminAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisterAdminService _registerAdminService;
        private readonly User _user;

        public RegisterUserAdminAppService(IUnitOfWork unitOfWork, IRegisterAdminService registerAdminService, User user)
        {
            _unitOfWork = unitOfWork;
            _registerAdminService = registerAdminService;
            _user = user;
        }

        public async Task RegisterAsync(RegisterAdminDTO dto)
        {
            if (_user == null)
            {
                Alert("user not found");
                return;
            }

            if (!_user.IsAdmin)
            {
                Alert("Only admin users can perform this action.");
                return;
            }

            var userExternalId = Guid.Empty;

            try
            {
                var userResult = await _registerAdminService.RegisterAsync(dto.Name, dto.Email, dto.Password);

                if(!userResult.Id.HasValue)
                {
                    foreach (var message in userResult.Erros)
                    {
                        Alert(message);
                    }

                    return;
                }

                userExternalId = userResult.Id.Value;

                var user = new User(dto.Name, dto.Email, userExternalId);

                var userRepository = _unitOfWork.ObterRepository<User>();

                var existUser = await userRepository.ExistsAsync(a => a.Email == dto.Email);

                if (existUser)
                {
                    Alert("User duplicate");
                    return;
                }

                if (user.Invalid)
                {
                    ImportAlerts(user);
                    return;
                }

                await userRepository.AddAsync(user);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                Alert($"Erro ao registrar usuário: {ex.Message}");
                return;
            }
        }
    }
}

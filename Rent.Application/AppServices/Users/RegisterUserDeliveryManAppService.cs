using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.Users;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;

namespace Rent.Application.AppServices.Users
{
    public class RegisterUserDeliveryManAppService : AppService, IRegisterUserDeliveryManAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisterDeliveryManService _registerDeliveryManService;

        public RegisterUserDeliveryManAppService(IUnitOfWork unitOfWork, IRegisterDeliveryManService registerDeliveryManService)
        {
            _unitOfWork = unitOfWork;
            _registerDeliveryManService = registerDeliveryManService;
        }

        public async Task RegisterAsync(Guid deliveryManId, RegisterUserDeliveryManDTO dto)
        {
            var userExternalId = Guid.Empty;

            try
            {
                var userResult = await _registerDeliveryManService.RegisterAsync(dto.Name, dto.Email, dto.Password);

                if(!userResult.Id.HasValue)
                {
                    foreach (var message in userResult.Erros)
                    {
                        Alert(message);
                    }

                    return;
                }

                userExternalId = userResult.Id.Value;

                var user = new User(dto.Name, dto.Email, userExternalId, deliveryManId);

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
            }
            catch (Exception ex)
            {
                Alert($"Erro ao registrar usuário: {ex.Message}");
                return;
            }
        }
    }
}

using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.DTOs.Motorcycles;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using Rent.Domain.MessagePublishers;

namespace Rent.Application.AppServices.Motorcycles
{
    public class RegisterMotorcycleAppService : AppService, IRegisterMotorcycleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly IMessagePublisher _messagePublisher;

        public RegisterMotorcycleAppService(IUnitOfWork unitOfWork, User user, IMessagePublisher messagePublisher)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _messagePublisher = messagePublisher;
        }

        public async Task RegisterAsync(AddMotorcycleDTO dto)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (!_user.Admin)
            {
                Alert("Only admin users can perform this action.");
                return;
            }

            var motorcycleRepository = _unitOfWork.ObterRepository<Motorcycle>();

            if (await motorcycleRepository.ExistsAsync(m => m.LicensePlate == dto.LicensePlate))
            {
                Alert("License plate already exists.");
                return;
            }

            var motorcycle = new Motorcycle(dto.Model, dto.Year, dto.LicensePlate);

            if (motorcycle.Invalid)
            {
                ImportAlerts(motorcycle);
                return;
            }

            await motorcycleRepository.AddAsync(motorcycle);

            await _unitOfWork.CommitAsync();

            await _messagePublisher.PublishAsync("motorcycle_registered", motorcycle);

            if (motorcycle.Year == 2024)
                await _messagePublisher.PublishAsync("motorcycle_2024_registered", motorcycle);
        }
    }
}

using MediatR;
using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.DTOs.Motorcycles;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using Rent.Domain.Events.Motorycles;

namespace Rent.Application.AppServices.Motorcycles
{
    public class RegisterMotorcycleAppService : AppService, IRegisterMotorcycleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly IEventBus _eventBus;
        private readonly IAppSettings _appSettings;

        public RegisterMotorcycleAppService(IUnitOfWork unitOfWork, User user, IEventBus eventBus, IAppSettings appSettings)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _eventBus = eventBus;
            _appSettings = appSettings;
        }

        public async Task RegisterAsync(AddMotorcycleDTO dto)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (!_user.IsAdmin)
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

            _eventBus.Publish(_appSettings.RabbitMq.Events.MotorcycleRegisteredEvent, new MotorcycleRegisteredEvent(motorcycle));

            if (motorcycle.Year == 2024)
                _eventBus.Publish(_appSettings.RabbitMq.Events.Motorcycle2024RegisteredEvent, new Motorcycle2024RegisteredEvent(motorcycle));
        }
    }
}

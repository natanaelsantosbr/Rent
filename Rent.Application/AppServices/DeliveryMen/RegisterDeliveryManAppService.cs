using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.DeliveryMen;
using Rent.Application.DTOs.Users;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Events.DeliveryMan;

namespace Rent.Application.AppServices.DeliveryMen
{
    public class RegisterDeliveryManAppService : AppService, IRegisterDeliveryManAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisterUserDeliveryManAppService _registerUserDeliveryManAppService;
        private readonly IAppSettings _appSettings;
        private readonly IEventBus _eventBus;

        public RegisterDeliveryManAppService(IUnitOfWork unitOfWork, IRegisterUserDeliveryManAppService registerUserDeliveryManAppService, IAppSettings appSettings, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _registerUserDeliveryManAppService = registerUserDeliveryManAppService;
            _appSettings = appSettings;
            _eventBus = eventBus;
        }

        public async Task<bool> RegisterDeliveryManAsync(RegisterDeliveryManDTO dto)
        {
            var repository = _unitOfWork.ObterRepository<DeliveryMan>();

            var cnpjExists = await repository.ExistsAsync(x => x.CNPJ == dto.CNPJ);

            if (cnpjExists)
            {
                Alert("This CNPJ is already registered.");
                return false;
            }

            var cnhExists = await repository.ExistsAsync(x => x.CNH == dto.CNH);
            if (cnhExists)
            {
                Alert("This CNH number is already registered.");
                return false;
            }


            var deliveryMan = new DeliveryMan(dto.Name, dto.CNPJ, dto.BirthDate, dto.CNH, dto.TypeCNH, dto.Email);

            if (deliveryMan.Invalid)
            {
                ImportAlerts(deliveryMan);
                return false;
            }

            await repository.AddAsync(deliveryMan);

            await _registerUserDeliveryManAppService.RegisterAsync(deliveryMan.Id, new RegisterUserDeliveryManDTO(dto.Name, dto.Email, dto.Password));

            if (_registerUserDeliveryManAppService.Invalid)
            {
                ImportAlerts(_registerUserDeliveryManAppService);
                return false;
            }

            await _unitOfWork.CommitAsync();

            _eventBus.Publish(_appSettings.RabbitMq.Events.CNHImageEvent, new CNHImageUploadEvent(deliveryMan.Id, dto.ImageCNH));

            return true;
        }

        private async Task<string> SaveCNHImageAsync(byte[] imageBytes, string fileName)
        {
            var filePath = Path.Combine(_appSettings.PathImageCNH, fileName + ".png");

            if (!Directory.Exists(_appSettings.PathImageCNH))
            {
                Directory.CreateDirectory(_appSettings.PathImageCNH);
            }

            await File.WriteAllBytesAsync(filePath, imageBytes);

            return filePath;
        }
    }
}

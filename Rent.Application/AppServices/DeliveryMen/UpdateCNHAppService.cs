using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Users;
using Rent.Domain.Events.DeliveryMan;

namespace Rent.Application.AppServices.DeliveryMen
{
    public class UpdateCNHAppService : AppService, IUpdateCNHAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly IAppSettings _appSettings;
        private readonly IEventBus _eventBus;

        public UpdateCNHAppService(IUnitOfWork unitOfWork, User user, IAppSettings appSettings, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _appSettings = appSettings;
            _eventBus = eventBus;
        }

        public async Task UpdateCNHAsync(byte[] image)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (!_user.DeliveryManId.HasValue)
            {
                Alert("Only delivery man");
                return;
            }

            var repository = _unitOfWork.ObterRepository<DeliveryMan>();

            var deliveryMan = await repository.GetByIdAsync(_user.DeliveryManId.Value);

            if (deliveryMan == null)
            {
                Alert("Delivery Man not found;");
                return;
            }

            _eventBus.Publish(_appSettings.RabbitMq.Events.CNHImageEvent, new CNHImageUploadEvent(deliveryMan.Id, image));

            var cnhImagePath = await SaveCNHImageAsync(image, deliveryMan.CNH);

            deliveryMan.UpdateCNHImagePath(cnhImagePath);

            if (deliveryMan.Invalid)
            {
                ImportAlerts(deliveryMan);
                return;
            }

            await _unitOfWork.CommitAsync();
            return;
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

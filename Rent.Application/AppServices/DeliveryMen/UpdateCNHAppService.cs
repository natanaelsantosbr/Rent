using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.DTOs.DeliveryMen;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;

namespace Rent.Application.AppServices.DeliveryMen
{
    public class UpdateCNHAppService : AppService, IUpdateCNHAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCNHAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateCNHAsync(Guid deliveryMenId, byte[] image)
        {
            var repository = _unitOfWork.ObterRepository<DeliveryMan>();

            var deliveryMan = await repository.ConsultarPorIdAsync(deliveryMenId);

            if (deliveryMan == null)
            {
                Alert("Delivery Man not found;");
                return;
            }

            var cnhImagePath = await SaveCNHImageAsync(image, deliveryMan.CNH + ".png");

            deliveryMan.UpdateCNHImagePath(cnhImagePath);

            if (deliveryMan.Invalid)
            {
                ImportAlerts(deliveryMan);
                return;
            }

            await repository.AdicionarAsync(deliveryMan);
            await _unitOfWork.CommitAsync();
            return;
        }

        private async Task<string> SaveCNHImageAsync(byte[] imageBytes, string fileName)
        {
            var filePath = Path.Combine("Images", fileName);

            if (!Directory.Exists("Images"))
            {
                Directory.CreateDirectory("Images");
            }

            await File.WriteAllBytesAsync(filePath, imageBytes);

            return filePath;
        }
    }
}

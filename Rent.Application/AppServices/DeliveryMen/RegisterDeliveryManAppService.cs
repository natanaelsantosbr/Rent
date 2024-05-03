using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.DTOs.DeliveryMen;
using Rent.Application.DTOs.Users;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;

namespace Rent.Application.AppServices.DeliveryMen
{
    public class RegisterDeliveryManAppService : AppService, IRegisterDeliveryManAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisterUserDeliveryManAppService _registerUserDeliveryManAppService;

        public RegisterDeliveryManAppService(IUnitOfWork unitOfWork, IRegisterUserDeliveryManAppService registerUserDeliveryManAppService)
        {
            _unitOfWork = unitOfWork;
            _registerUserDeliveryManAppService = registerUserDeliveryManAppService;
        }

        public async Task<bool> RegisterDeliveryManAsync(RegisterDeliveryManDTO dto)
        {
            var repository = _unitOfWork.ObterRepository<DeliveryMan>();

            if (await repository.ExisteAsync(x => x.CNPJ == dto.CNPJ))
            {
                Alert("This CNPJ is already registered.");
                return false;
            }

            if (await repository.ExisteAsync(x => x.CNH == dto.CNH))
            {
                Alert("This CNH number is already registered.");
                return false;
            }

            var cnhImagePath = await SaveCNHImageAsync(dto.CNHImage, dto.CNH + ".png");

            var deliveryMan = new DeliveryMan(dto.Name, dto.CNPJ, dto.BirthDate, dto.CNH, dto.TypeCNH, dto.Email, cnhImagePath);

            if (deliveryMan.Invalid)
            {
                ImportAlerts(deliveryMan);
                return false;
            }

            await repository.AdicionarAsync(deliveryMan);

            await _registerUserDeliveryManAppService.Register(deliveryMan.Id, new RegisterUserDeliveryManDTO(dto.Name, dto.Email, dto.Password));

            if (_registerUserDeliveryManAppService.Invalid)
            {
                ImportAlerts(_registerUserDeliveryManAppService);
                return false;
            }

            await _unitOfWork.CommitAsync();

            return true;
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

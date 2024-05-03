using Rent.Application.DTOs.Users;

namespace Rent.Application.Abstractions.AppServices.Users
{
    public interface IRegisterUserDeliveryManAppService : IAppService
    {
        Task RegisterAsync(Guid deliveryManId, RegisterUserDeliveryManDTO dto);
    }
}

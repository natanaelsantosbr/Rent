using Rent.Application.DTOs.DeliveryMen;

namespace Rent.Application.Abstractions.AppServices.DeliveryMen
{
    public interface IRegisterDeliveryManAppService : IAppService
    {
        Task<bool> RegisterDeliveryManAsync(RegisterDeliveryManDTO dto);
    }
}

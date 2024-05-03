using Rent.Application.DTOs.Motorcycles;

namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface IRegisterMotorcycleAppService : IAppService
    {
        Task RegisterAsync(AddMotorcycleDTO dto);
    }
}

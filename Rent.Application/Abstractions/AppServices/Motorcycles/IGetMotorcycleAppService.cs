using Rent.Application.DTOs.Motorcycles;

namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface  IGetMotorcycleAppService : IAppService
    {
        ICollection<ListMotorcycleDTO> GetMotorcycleByLicensePlateAsync(string? licensePlate);
    }
}

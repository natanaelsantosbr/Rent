using Rent.Application.DTOs.MotorycleRentals;

namespace Rent.Application.Abstractions.AppServices.MotorycleRentals
{
    public interface IMotorycleRentalAppService : IAppService
    {
        Task RentMotorcycleAsync(MotorycleRentalDTO dto);
    }
}

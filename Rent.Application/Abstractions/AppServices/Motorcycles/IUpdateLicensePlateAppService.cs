namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface IUpdateLicensePlateAppService : IAppService
    {
        Task<bool> UpdateLicensePlateAppAsync(Guid motorcycleId, string licensePlate);
    }
}

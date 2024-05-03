namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface IRemoveMotorcycleAppService : IAppService
    {
        Task RemoveAsync(Guid motorcycleId);
    }
}

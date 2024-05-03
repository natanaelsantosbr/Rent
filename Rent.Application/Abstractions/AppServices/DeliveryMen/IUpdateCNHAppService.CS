namespace Rent.Application.Abstractions.AppServices.DeliveryMen
{
    public interface IUpdateCNHAppService : IAppService
    {
        Task UpdateCNHAsync(byte[] image);
    }
}

namespace Rent.Domain.Services.Accounts
{
    public interface IRegisterDeliveryManService
    {
        Task<UserResultDTO> RegisterAsync(string name, string email, string password);
    }
}

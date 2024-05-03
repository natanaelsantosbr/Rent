namespace Rent.Domain.Services.Accounts
{
    public interface IRegisterAdminService
    {
        Task<UserResultDTO> RegisterAsync(string name, string email, string password);
    }
}

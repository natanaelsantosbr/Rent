namespace Rent.Domain.Services.Accounts
{
    public interface IAuthenticateService
    {
        Task<bool> AuthenticateAsync(string email, string password);
    }
}

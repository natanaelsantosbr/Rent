using Rent.Application.DTOs.Accounts;

namespace Rent.Application.Abstractions.AppServices.Accounts
{
    public interface IAuthenticateAppService : IAppService
    {
        Task<UserTokenDTO> AuthenticateAsync(string email, string password);
    }
}

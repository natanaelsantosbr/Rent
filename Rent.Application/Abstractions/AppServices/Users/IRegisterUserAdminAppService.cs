using Rent.Application.DTOs.Users;

namespace Rent.Application.Abstractions.AppServices.Users
{
    public interface IRegisterUserAdminAppService : IAppService
    {
        Task RegisterAsync(RegisterAdminDTO dto);
    }
}

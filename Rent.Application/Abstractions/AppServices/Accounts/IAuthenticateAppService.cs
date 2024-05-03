using Rent.Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.Accounts
{
    public interface IAuthenticateAppService : IAppService
    {
        Task<UserTokenDTO> Authenticate(string email, string password);
    }
}

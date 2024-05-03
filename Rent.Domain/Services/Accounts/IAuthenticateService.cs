using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Services.Accounts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
    }
}

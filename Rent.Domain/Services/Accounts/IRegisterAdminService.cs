using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Services.Accounts
{
    public interface IRegisterAdminService
    {
        Task<UserResult> Register(string name, string email, string password);
    }
}

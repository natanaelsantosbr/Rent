using Rent.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.Users
{
    public interface IRegisterUserAdminAppService : IAppService
    {
        Task Register(RegisterAdminDTO dto);
    }
}

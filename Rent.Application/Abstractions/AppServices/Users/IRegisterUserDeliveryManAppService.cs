using Rent.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.Users
{
    public interface IRegisterUserDeliveryManAppService : IAppService
    {
        Task Register(Guid deliveryManId, RegisterUserDeliveryManDTO dto);
    }
}

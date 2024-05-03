using Rent.Application.Abstractions;
using Rent.Application.DTOs.MotorycleRentals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.MotorycleRentals
{
    public interface IMotorycleRentalAppService : IAppService
    {
        Task RentMotorcycleAsync(MotorycleRentalDTO dto);
    }
}

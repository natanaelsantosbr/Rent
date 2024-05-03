using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.MotorycleRentals
{
    public interface ICalculateReturnCostAppService : IAppService
    {
        Task<decimal> CalculeReturnCostAsync(Guid rentalId, DateTime returnDate);
    }
}

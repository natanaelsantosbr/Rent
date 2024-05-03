using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.MotorycleRentals;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.MotorcycleRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.AppServices.MotorycleRentals
{
    public class CalculateReturnCostAppService : AppService, ICalculateReturnCostAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalculateReturnCostAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> CalculeReturnCostAsync(Guid rentalId, DateTime returnDate)
        {
            var _rentalRepository = _unitOfWork.ObterRepository<MotorcycleRental>();

            var rental = await _rentalRepository.ConsultarPorIdAsync(rentalId);

            if (rental == null)
            {
                Alert("Rental not found.");
                return 0;
            }

            return rental.CalculateReturnCost(returnDate);
        }
    }
}

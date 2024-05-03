using Rent.Application.Abstractions;
using Rent.Application.DTOs.MotorycleRentals;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.MotorcycleRentals;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.MotorycleRentals
{
    public class MotorycleRentalAppService : AppService, IMotorycleRentalAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;

        public MotorycleRentalAppService(User user, IUnitOfWork unitOfWork)
        {
            _user = user;
            _unitOfWork = unitOfWork;
        }

        public async Task RentMotorcycleAsync(MotorycleRentalDTO dto)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (_user.Admin || !_user.DeliveryManId.HasValue)
            {
                Alert("Only delivery man users can perform this action.");
                return;
            }


            var deliveryManRepository = _unitOfWork.ObterRepository<DeliveryMan>();

            var deliveryMan = await deliveryManRepository.ConsultarPorIdAsync(_user.DeliveryManId.Value);

            if (deliveryMan == null)
            { 
                Alert("Delivery Man not found.");
                return;
            }

            if(!deliveryMan.CanRent())
            {
                Alert("Delivery man is not eligible to rent.");
                return;
            }

            var rental = new MotorcycleRental(dto.MotorcycleId, dto.CreationDate, dto.RentalPeriod, deliveryMan.CanRent());

            if(rental.Invalid)
            {
                ImportAlerts(rental);
                return;
            }

            var motorcycleRentalRepository = _unitOfWork.ObterRepository<MotorcycleRental>();   
            await motorcycleRentalRepository.AdicionarAsync(rental);
            await _unitOfWork.CommitAsync();


        }
    }
}

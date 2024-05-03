using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.AppServices.Motorcycles
{
    public class UpdateLicensePlateAppService : AppService, IUpdateLicensePlateAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;

        public UpdateLicensePlateAppService(IUnitOfWork unitOfWork, User user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }

        public async Task<bool> UpdateLicensePlateAppAsync(Guid motorcycleId, string licensePlate)
        {
            if (_user == null)
            {
                Alert("User not found");
                return false;
            }

            if (!_user.Admin)
            {
                Alert("Only admin users can perform this action.");
                return false;
            }


            var motorcycleRepository = _unitOfWork.ObterRepository<Motorcycle>();
            var motorcycle = await motorcycleRepository.ConsultarPorIdAsync(motorcycleId);

            if (motorcycle == null)
            {
                Alert("Motorycle not found");
                return false;
            }

            var isLicensePlateInUse = await motorcycleRepository.ExisteAsync(a => a.LicensePlate == licensePlate);

            if(isLicensePlateInUse)
            {
                Alert("License plate already in use.");
                return false;
            }

            motorcycle.UpdateLicensePlate(licensePlate);

            if(motorcycle.Invalid)
            {
                ImportAlerts(motorcycle);
                return false;
            }

            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}

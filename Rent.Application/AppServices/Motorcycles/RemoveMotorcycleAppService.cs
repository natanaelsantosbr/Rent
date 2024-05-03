using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.MotorcycleRentals;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;

namespace Rent.Application.AppServices.Motorcycles
{
    public class RemoveMotorcycleAppService : AppService, IRemoveMotorcycleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;

        public RemoveMotorcycleAppService(IUnitOfWork unitOfWork, User user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }


        public async Task RemoveAsync(Guid motorcycleId)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (!_user.Admin)
            {
                Alert("Only admin users can perform this action.");
                return;
            }

            var motorcycleRepository = _unitOfWork.ObterRepository<Motorcycle>();

            var motorcycle = await motorcycleRepository.ExistsAsync(a => a.Id == motorcycleId);

            if (!motorcycle)
            {
                Alert("Motorcycle not found");
                return;
            }

            var motorcycleRentalRepository = _unitOfWork.ObterRepository<MotorcycleRental>();

            var rental = await motorcycleRentalRepository.ExistsAsync(a => a.MotorcycleId == motorcycleId);

            if (rental)
            {
                Alert("Cannot remove motorcycle with active or past rentals");
                return;
            }

            await motorcycleRepository.DeleteAsync(motorcycleId);
            await _unitOfWork.CommitAsync();
        }
    }
}

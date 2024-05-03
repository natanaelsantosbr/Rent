using Rent.Domain.Entities.MotorcycleRentals;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class MotorcycleRentalRepository : Repository<MotorcycleRental>, IMotorcycleRentalRepository
    {
        public MotorcycleRentalRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

using Rent.Domain.Entities.Motorcycles;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

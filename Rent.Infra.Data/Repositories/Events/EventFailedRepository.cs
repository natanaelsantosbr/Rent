using Rent.Domain.Entities.Events;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class EventFailedRepository : Repository<EventFailed>, IEventFailedRepository
    {
        public EventFailedRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

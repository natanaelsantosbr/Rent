using Rent.Domain.Entities.Events;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

using MediatR;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Domain.Events.Motorycles
{
    public class Motorcycle2024RegisteredEvent : INotification
    {
        public Motorcycle Motorcycle { get; }

        public Motorcycle2024RegisteredEvent(Motorcycle motorcycle)
        {
            Motorcycle = motorcycle;
        }
    }
}

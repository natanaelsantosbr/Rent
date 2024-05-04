using MediatR;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Domain.Events.Motorycles
{
    public class Motorcycle2024RegisteredNotification : INotification
    {
        public Motorcycle Motorcycle { get; }

        public Motorcycle2024RegisteredNotification(Motorcycle motorcycle)
        {
            Motorcycle = motorcycle;
        }
    }
}

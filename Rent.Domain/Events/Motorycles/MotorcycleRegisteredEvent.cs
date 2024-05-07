using MediatR;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Domain.Events.Motorycles
{
    public class MotorcycleRegisteredEvent : INotification
    {
        public Motorcycle Motorcycle { get;  }

        public MotorcycleRegisteredEvent(Motorcycle motorcycle)
        {
            Motorcycle = motorcycle;
        }
    }
}

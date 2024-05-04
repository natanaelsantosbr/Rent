using MediatR;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Domain.Events.Motorycles
{
    public class MotorcycleRegisteredNotification : INotification
    {
        public Motorcycle Motorcycle { get;  }

        public MotorcycleRegisteredNotification(Motorcycle motorcycle)
        {
            Motorcycle = motorcycle;
        }
    }
}

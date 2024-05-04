using MediatR;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Events;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Events.Motorycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Events.Motorcycles
{
    public class MotorcycleRegisteredHandler : INotificationHandler<MotorcycleRegisteredNotification>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MotorcycleRegisteredHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(MotorcycleRegisteredNotification notification, CancellationToken cancellationToken)
        {
            var eventRepository = _unitOfWork.ObterRepository<Event>();

            var name = $"Motorcycle registered {notification.Motorcycle.Id} {notification.Motorcycle.Model}";
            var @event = new Event(name, DateTime.Now);

            await eventRepository.AddAsync(@event);

            await _unitOfWork.CommitAsync();
        }
    }
}

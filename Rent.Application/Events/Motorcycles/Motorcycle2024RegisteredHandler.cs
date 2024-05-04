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
    public class Motorcycle2024RegisteredHandler : INotificationHandler<Motorcycle2024RegisteredNotification>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Motorcycle2024RegisteredHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Motorcycle2024RegisteredNotification notification, CancellationToken cancellationToken)
        {
            var eventRepository = _unitOfWork.ObterRepository<Event>();

            var name = $"Motorcycle 2024 registered {notification.Motorcycle.Id} {notification.Motorcycle.Model}";
            var @event = new Event(name, DateTime.Now);

            await eventRepository.AddAsync(@event);

            await _unitOfWork.CommitAsync();
        }
    }
}

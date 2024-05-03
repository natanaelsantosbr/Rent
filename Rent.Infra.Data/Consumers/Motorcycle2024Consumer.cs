using Microsoft.Extensions.Logging;
using Rent.Domain.Abstractions.Repositories;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Events;
using Rent.Domain.Entities.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Consumers
{
    public class Motorcycle2024Consumer
    {
        private readonly IUnitOfWork _unitOfWork;

        public Motorcycle2024Consumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(Motorcycle motorcycle)
        {
            var details = $"Motorcycle for 2024 registered: {motorcycle.Model}, {motorcycle.LicensePlate}";

            var @event = new Event(details, DateTime.Now);

            var eventRepository = _unitOfWork.ObterRepository<Event>();

            await eventRepository.AdicionarAsync(@event);

            await _unitOfWork.CommitAsync();
        }
    }
}

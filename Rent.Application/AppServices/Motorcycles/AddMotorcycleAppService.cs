using AutoMapper;
using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.DTOs.Motorcycles;
using Rent.Application.MessagePublishers;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.AppServices.Motorcycles
{
    public class AddMotorcycleAppService : AppService, IAddMotorcycleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly IMapper _mapper;
        private readonly IMessagePublisher _messagePublisher;

        public AddMotorcycleAppService(IUnitOfWork unitOfWork, User user, IMapper mapper, IMessagePublisher messagePublisher)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }

        public async Task AddMotorcycleAsync(AddMotorcycleDTO dto)
        {
            if (_user == null)
            {
                Alert("User not found");
                return;
            }

            if (!_user.Admin)
            {
                Alert("Only admin users can perform this action.");
                return;
            }

            var motorcycleRepository = _unitOfWork.ObterRepository<Motorcycle>();

            if (await motorcycleRepository.ExisteAsync(m => m.LicensePlate == dto.LicensePlate))
            {
                Alert("License plate already exists.");
                return;
            }

            var motorcycle = new Motorcycle(dto.Model, dto.Year, dto.LicensePlate);

            if (motorcycle.Invalid)
            {
                ImportAlerts(motorcycle);
                return;
            }

            await motorcycleRepository.AdicionarAsync(motorcycle);

            await _unitOfWork.CommitAsync();

            await _messagePublisher.PublishAsync("motorcycle_registered", motorcycle);

            if (motorcycle.Year == 2024)
                await _messagePublisher.PublishAsync("motorcycle_2024_registered", motorcycle);
        }
    }
}

using AutoMapper;
using Rent.Application.Abstractions;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.DTOs.Motorcycles;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.AppServices.Motorcycles
{
    public class GetMotorcycleAppService : AppService, IGetMotorcycleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly IMapper _mapper;

        public GetMotorcycleAppService(IUnitOfWork unitOfWork, User user, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _mapper = mapper;
        }

        public ICollection<ListMotorcycleDTO> GetMotorcycleByLicensePlateAsync(string? licensePlate)
        {
            var motorcycleRepository = _unitOfWork.ObterRepository<Motorcycle>();

            var list = motorcycleRepository.Consultar();

            if(licensePlate != null)
                list = list.Where(a => a.LicensePlate.Contains(licensePlate));

            var dtos = _mapper.Map<ICollection<ListMotorcycleDTO>>(list);

            return dtos;
        }
    }
}

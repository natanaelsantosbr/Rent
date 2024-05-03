using AutoMapper;
using Rent.Application.DTOs.Motorcycles;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Application.AutoMapper
{
    public class MotorcycleProfile : Profile
    {
        public MotorcycleProfile()
        {
            CreateMap<Motorcycle, ListMotorcycleDTO>();
        }
    }
}

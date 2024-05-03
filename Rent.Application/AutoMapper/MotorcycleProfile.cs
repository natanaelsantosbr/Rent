using AutoMapper;
using Rent.Application.DTOs.Motorcycles;
using Rent.Domain.Entities.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

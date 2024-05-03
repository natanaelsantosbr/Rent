using Rent.Application.DTOs.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.Abstractions.AppServices.Motorcycles
{
    public interface  IGetMotorcycleAppService : IAppService
    {
        ICollection<ListMotorcycleDTO> GetMotorcycleByLicensePlateAsync(string? licensePlate);
    }
}

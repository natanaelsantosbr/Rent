using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Application.DTOs.Motorcycles
{
    public class ListMotorcycleDTO
    {
        public string Identifier { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
    }
}

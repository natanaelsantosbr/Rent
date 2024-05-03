using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.Motorcycles
{
    public class Motorcycle : BaseEntity
    {
        public string Identifier { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }

        public Motorcycle(string identifier, string model, int year, string licensePlate)
        {
            Identifier = identifier;
            Model = model;
            Year = year;
            LicensePlate = licensePlate;
        }

        public void UpdateLicensePlate(string licensePlate)
        {
            LicensePlate = licensePlate;
        }
    }
}

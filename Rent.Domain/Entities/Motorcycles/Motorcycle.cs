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
        public string VIN { get; private set; } // Vehicle Identification Number

        public Motorcycle(string identifier, string model, int year, string vin)
        {
            Identifier = identifier;
            Model = model;
            Year = year;
            VIN = vin;
        }

        public void ChangeVIN(string vin)
        {
            VIN = vin;
        }
    }
}

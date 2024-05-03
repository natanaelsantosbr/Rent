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
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string LicensePlate { get; private set; }

        public Motorcycle(string model, int year, string licensePlate)
        {
            Model = model;
            Year = year;
            LicensePlate = licensePlate;

            Validate();
        }

        public void UpdateLicensePlate(string licensePlate)
        {
            LicensePlate = licensePlate;
        }

        private void Validate()
        {
            if (Year < 1900 || Year > DateTime.Now.Year + 1)
                Alert("Year is invalid.");

            if (string.IsNullOrEmpty(Model))
                Alert("Model is required.");

            if (string.IsNullOrEmpty(LicensePlate))
                Alert("License plate is required.");
        }
    }
}

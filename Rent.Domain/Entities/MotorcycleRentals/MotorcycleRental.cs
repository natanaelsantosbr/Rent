using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.MotorcycleRentals
{
    public class MotorcycleRental : BaseEntity
    {
        public Guid MotorcycleId { get; private set; }
        public Guid DeliveryManId { get; private set; }    
        public DateTime CreationDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public int RentalPeriod { get; private set; }
        public decimal DailyRate { get; private set; }
        public decimal TotalCost { get; private set; }
        public bool IsDriverEligible { get; private set; }

        public MotorcycleRental(DateTime creationDate, int rentalPeriod, bool isDriverEligible)
        {
            CreationDate = creationDate;
            StartDate = CreationDate.AddDays(1);
            RentalPeriod = rentalPeriod;
            IsDriverEligible = isDriverEligible;

            CalculateCosts();
            SetEndDates();
        }

        private void CalculateCosts()
        {
            if (!IsDriverEligible)
                Alert("Only drivers with category A license are eligible for rental.");

            if (RentalPeriod == 7) DailyRate = 30.00m;
            else if (RentalPeriod == 15) DailyRate = 28.00m;
            else if (RentalPeriod == 30) DailyRate = 22.00m;
            else if (RentalPeriod == 45) DailyRate = 20.00m;
            else if (RentalPeriod == 50) DailyRate = 18.00m;
            else 
                Alert("Invalid rental period. Only specific plans are available.");

            TotalCost = DailyRate * RentalPeriod;
        }

        private void SetEndDates()
        {
            EndDate = StartDate.AddDays(RentalPeriod - 1);
            ExpectedEndDate = EndDate;
        }
    }
}

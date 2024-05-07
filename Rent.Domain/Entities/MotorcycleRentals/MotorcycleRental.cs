using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Domain.Entities.MotorcycleRentals
{
    public class MotorcycleRental : BaseEntity
    {
        protected MotorcycleRental() { }

        public Guid MotorcycleId { get; private set; }
        public Motorcycle Motorcycle { get; private set; }
        public Guid DeliveryManId { get; private set; }
        public DeliveryMan DeliveryMan { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public RentalPeriodEnum RentalPeriod { get; private set; }
        public decimal DailyRate { get; private set; }
        public decimal TotalCost { get; private set; }
        public bool IsDriverEligible { get; private set; }

        public MotorcycleRental(Guid deliveryManId, Guid motorcycleId, DateTime creationDate, RentalPeriodEnum rentalPeriod, bool isDriverEligible)
        {
            DeliveryManId = deliveryManId;
            MotorcycleId = motorcycleId;
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

            switch(RentalPeriod)
            {
                case RentalPeriodEnum._7:
                    DailyRate = 30.00m;
                    break;
                case RentalPeriodEnum._15:
                    DailyRate = 28.00m;
                    break;
                    case RentalPeriodEnum._30:
                    DailyRate = 22.00m;
                    break;
                    case RentalPeriodEnum._45:
                    DailyRate = 20.00m;
                    break;
                case RentalPeriodEnum._50:
                    DailyRate = 18.00m;
                    break;
                default:
                    Alert("Invalid rental period. Only specific plans are available.");
                    break;
            }

            TotalCost = DailyRate * (int)RentalPeriod;
        }

        private void SetEndDates()
        {
            EndDate = StartDate.AddDays((int)RentalPeriod - 1);
            ExpectedEndDate = EndDate;
        }

        public decimal CalculateReturnCost(DateTime returnDate)
        {
            int daysLate = (returnDate - ExpectedEndDate).Days;
            if (daysLate > 0)
            {
                return TotalCost + (50m * daysLate);
            }
            else if (daysLate < 0)
            {
                int daysEarly = -daysLate;
                decimal penaltyRate = 0;
                if (RentalPeriod ==  RentalPeriodEnum._7) penaltyRate = 0.20m;
                else if (RentalPeriod ==  RentalPeriodEnum._15) penaltyRate = 0.40m;

                decimal penalty = (DailyRate * daysEarly) * penaltyRate;
                return TotalCost - penalty;
            }

            return TotalCost; 
        }
    }
}

using Rent.Domain.Entities.MotorcycleRentals;

namespace Rent.Application.DTOs.MotorycleRentals
{
    public class MotorycleRentalDTO
    {
        public Guid MotorcycleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public RentalPeriodEnum RentalPeriod { get; set; }
    }
}

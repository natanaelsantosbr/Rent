using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.MotorcycleRentals;

namespace Rent.Infra.Data.Mappings.DeliveryMen
{
    public class MotorcycleRentalMap : IEntityTypeConfiguration<MotorcycleRental>
    {
        public void Configure(EntityTypeBuilder<MotorcycleRental> builder)
        {
            builder.ToTable("MotorcycleRentals");
            builder.Ignore(c => c.Alerts);
        }
    }
}

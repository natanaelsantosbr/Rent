using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.Motorcycles;

namespace Rent.Infra.Data.Mappings.DeliveryMen
{
    public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> builder)
        {
            builder.ToTable("Motorcycles");

            builder.Property(c => c.Model).HasMaxLength(300);
            builder.Property(c => c.LicensePlate).HasMaxLength(50);

            builder.Ignore(c => c.Alerts);
        }
    }
}

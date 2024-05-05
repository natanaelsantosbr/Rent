using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.DeliveryMen;

namespace Rent.Infra.Data.Mappings.DeliveryMen
{
    public class DeliveryMenMap : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(300);
            builder.Property(c => c.CNPJ).HasMaxLength(14);
            builder.Property(c => c.CNH).HasMaxLength(11);
            builder.Property(c => c.Email).HasMaxLength(300);
            builder.Property(c => c.CNHImagePath).HasMaxLength(300);

            builder.Ignore(c => c.Alerts);
        }
    }
}

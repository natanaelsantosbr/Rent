using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.DeliveryMen;

namespace Rent.Infra.Data.Mappings.DeliveryMen
{
    public class DeliveryMenMap : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.ToTable("DeliveryMen");
            builder.Ignore(c => c.Alerts);
        }
    }
}

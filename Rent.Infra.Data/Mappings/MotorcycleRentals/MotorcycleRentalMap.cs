using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Events;
using Rent.Domain.Entities.MotorcycleRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

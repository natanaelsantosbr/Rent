using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rent.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Mappings.Events
{
    public class EventFailedMap : IEntityTypeConfiguration<EventFailed>
    {
        public void Configure(EntityTypeBuilder<EventFailed> builder)
        {
            builder.ToTable("EventsFailed");
            builder.Ignore(c => c.Alerts);
        }
    }
}

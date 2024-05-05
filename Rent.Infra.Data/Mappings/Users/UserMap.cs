using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rent.Domain.Entities.Users;

namespace Rent.Infra.Data.Mappings.DeliveryMen
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(c => c.Name).HasMaxLength(300);
            builder.Property(c => c.Email).HasMaxLength(300);
            builder.Ignore(c => c.Alerts);
        }
    }
}

using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent.Domain.Abstractions.Validations;
using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Events;
using Rent.Domain.Entities.MotorcycleRentals;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using Rent.Infra.Data.Identity;

namespace Rent.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MotorcycleRental> MotorcycleRentals { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Ignore<Validable>();
            builder.Ignore<Notifiable>();
            builder.Ignore<Notification>();

            CreateRoles(builder);
        }

        private static void CreateRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                            new IdentityRole { Id = "6affca0c-551c-4d00-a3a1-d1641d09f5e6", Name = "admin", NormalizedName = "ADMIN", ConcurrencyStamp = "82612521-ae33-41f3-9102-54df447665bb" },
                            new IdentityRole { Id = "e204963b-3484-4bba-b83a-9261694ad9e1", Name = "deliveryman", NormalizedName = "DELIVERYMAN", ConcurrencyStamp = "d0560a5f-8c03-40b5-be69-8bcd9aee7dd0" }
                        );
        }
    }
}

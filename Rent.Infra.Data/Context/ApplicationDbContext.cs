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
        public DbSet<EventFailed> EventsFailed { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Ignore<Validable>();
            builder.Ignore<Notifiable>();
            builder.Ignore<Notification>();

            CreateRoles(builder);

            CreateAdmin(builder);
        }

        private void CreateAdmin(ModelBuilder builder)
        {
            string ADMIN_ID = "d146dfe8-b61b-4d82-944f-4f9b5125ef60";
            string ROLE_ID = "49cd13d0-9a2a-4115-bc48-f9f3ba5be1f7";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var appUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                Name = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Admin@10");

            builder.Entity<ApplicationUser>().HasData(appUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            var user = new User(appUser.Name, appUser.Email, Guid.Parse(appUser.Id));

            builder.Entity<User>().HasData(user);   
        }

        private static void CreateRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                            new IdentityRole { Id = "e204963b-3484-4bba-b83a-9261694ad9e1", Name = "deliveryman", NormalizedName = "DELIVERYMAN", ConcurrencyStamp = "d0560a5f-8c03-40b5-be69-8bcd9aee7dd0" }
                        );
        }
    }
}

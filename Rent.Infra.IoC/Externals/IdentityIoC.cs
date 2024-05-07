using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Infra.Data.Context;
using Rent.Infra.Data.Identity;

namespace Rent.Infra.IoC.Externals
{
    public static class IdentityIoC
    {
        public static IServiceCollection AddIdentityIoC(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}

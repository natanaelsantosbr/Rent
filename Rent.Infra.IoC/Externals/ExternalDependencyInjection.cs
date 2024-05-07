using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rent.Infra.IoC.Externals
{
    public static class ExternalDependencyInjection
    {
        public static IServiceCollection AddExternalDependencyInjectionIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseIoC(configuration);
            services.AddIdentityIoC();
            services.AddRabbitIoC();

            return services;
        }
    }
}

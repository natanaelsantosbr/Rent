using Rent.API.Configurations;
using Rent.Infra.IoC;

namespace Rent.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection Configurar(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();

            services.AddAPIDependencyInjectionIoC(configuration);
            services.AddAutoMapperConfig();

            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions;
using Rent.Domain.Abstractions.Entities;

namespace Rent.Infra.IoC.Externals
{
    public static class MediatrIoC
    {
        public static IServiceCollection AddMediatRIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BaseEntity).Assembly, typeof(AppService).Assembly));

            return services;
        }
    }
}

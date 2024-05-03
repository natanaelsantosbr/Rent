using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.AppServices.Motorcycles;

namespace Rent.Infra.IoC.Entities.DeliveryMen
{
    public static class MotorcyclesIoC
    {
        public static IServiceCollection AddMotorcyclesIoC(this IServiceCollection services)
        {
            services.AddScoped<IRegisterMotorcycleAppService, RegisterMotorcycleAppService>();
            services.AddScoped<IGetMotorcycleAppService, GetMotorcycleAppService>();
            services.AddScoped<IRemoveMotorcycleAppService, RemoveMotorcycleAppService>();
            services.AddScoped<IUpdateLicensePlateAppService, UpdateLicensePlateAppService>();

            return services;

        }
    }
}

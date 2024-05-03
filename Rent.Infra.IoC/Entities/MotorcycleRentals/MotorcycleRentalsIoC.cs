using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.MotorycleRentals;
using Rent.Application.AppServices.MotorycleRentals;

namespace Rent.Infra.IoC.Entities.DeliveryMen
{
    public static class MotorcycleRentalsIoC
    {
        public static IServiceCollection AddMotorcycleRentalsIoC(this IServiceCollection services)
        {
            services.AddScoped<ICalculateReturnCostAppService, CalculateReturnCostAppService>();
            services.AddScoped<IMotorycleRentalAppService, MotorycleRentalAppService>();
            return services;

        }
    }
}

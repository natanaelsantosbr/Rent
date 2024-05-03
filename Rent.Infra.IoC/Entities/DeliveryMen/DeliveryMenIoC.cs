using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.AppServices.DeliveryMen;

namespace Rent.Infra.IoC.Entities.DeliveryMen
{
    public static class DeliveryMenIoC
    {
        public static IServiceCollection AddDeliveryMenIoC(this IServiceCollection services)
        {
            services.AddScoped<IRegisterDeliveryManAppService, RegisterDeliveryManAppService>();
            services.AddScoped<IUpdateCNHAppService, UpdateCNHAppService>();

            return services;

        }
    }
}

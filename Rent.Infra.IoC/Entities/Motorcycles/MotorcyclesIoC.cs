using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.AppServices.Motorcycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Entities.DeliveryMen
{
    public static class MotorcyclesIoC
    {
        public static IServiceCollection AddMotorcyclesIoC(this IServiceCollection services)
        {
            services.AddScoped<IAddMotorcycleAppService, AddMotorcycleAppService>();
            services.AddScoped<IGetMotorcycleAppService, GetMotorcycleAppService>();
            services.AddScoped<IRemoveMotorcycleAppService, RemoveMotorcycleAppService>();
            services.AddScoped<IUpdateLicensePlateAppService, UpdateLicensePlateAppService>();

            return services;

        }
    }
}

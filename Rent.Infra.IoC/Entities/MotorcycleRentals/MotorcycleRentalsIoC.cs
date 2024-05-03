using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.Abstractions.AppServices.Motorcycles;
using Rent.Application.Abstractions.AppServices.MotorycleRentals;
using Rent.Application.AppServices.DeliveryMen;
using Rent.Application.AppServices.Motorcycles;
using Rent.Application.AppServices.MotorycleRentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

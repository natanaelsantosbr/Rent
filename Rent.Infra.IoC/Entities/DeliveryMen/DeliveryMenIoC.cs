using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.DeliveryMen;
using Rent.Application.AppServices.DeliveryMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

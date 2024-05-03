using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Infra.IoC.Entities.DeliveryMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Entities
{
    public static class InjecaoDeDependenciaRegraNegocio
    {
        public static IServiceCollection AddInjecaoDeDendenciaRegraNegocioIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDeliveryMenIoC();
            services.AddEventsIoC();
            services.AddMotorcycleRentalsIoC();
            services.AddMotorcyclesIoC();
            services.AddUsersIoC();

            return services;
        }
    }
}

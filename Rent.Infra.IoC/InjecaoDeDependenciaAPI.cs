using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Infra.IoC.Entities;
using Rent.Infra.IoC.Externals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC
{
    public static class InjecaoDeDependenciaAPI
    {
        public static IServiceCollection AddInjencaoDeDependenciaAPIIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInjecaoDeDendenciaRegraNegocioIoC(configuration);
            services.AddInjecaoDeDependenciaExternaIoC(configuration);
            //services.AddJWTIoC(configuration);
            return services;
        }
    }
}

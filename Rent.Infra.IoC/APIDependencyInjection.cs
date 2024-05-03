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
    public static class APIDependencyInjection
    {
        public static IServiceCollection AddAPIDependencyInjectionIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessRuleDependencyInjectionIoC(configuration);
            services.AddExternalDependencyInjectionIoC(configuration);
            services.AddJwtAuthentication(configuration);
            return services;
        }
    }
}

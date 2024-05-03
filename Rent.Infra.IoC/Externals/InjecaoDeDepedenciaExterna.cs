using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Externals
{
    public static class InjecaoDeDepedenciaExterna
    {
        public static IServiceCollection AddInjecaoDeDependenciaExternaIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseIoC(configuration);
            services.AddIdentityIoC(configuration);

            return services;
        }
    }
}

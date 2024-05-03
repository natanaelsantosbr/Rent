using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static T Get<T>(this IServiceCollection services)
        {
            return services
                .BuildServiceProvider()
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<T>(); ;
        }
    }
}

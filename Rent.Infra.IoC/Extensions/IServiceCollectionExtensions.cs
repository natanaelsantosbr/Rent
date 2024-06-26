﻿using Microsoft.Extensions.DependencyInjection;

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

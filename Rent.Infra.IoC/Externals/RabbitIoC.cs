﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions;
using Rent.Application.Events;
using Rent.Domain.Abstractions.Entities;
using Rent.Infra.Data.Messaging;

namespace Rent.Infra.IoC.Externals
{
    public static class RabbitIoC
    {
        public static IServiceCollection AddRabbitIoC(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQEventBus>();
            services.AddHostedService<RabbitMQConsumerService>();

            return services;
        }
    }
}

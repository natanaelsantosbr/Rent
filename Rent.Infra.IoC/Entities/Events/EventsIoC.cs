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
    public static class EventsIoC
    {
        public static IServiceCollection AddEventsIoC(this IServiceCollection services)
        {
            
            return services;
        }
    }
}

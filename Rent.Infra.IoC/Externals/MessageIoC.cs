using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rent.Domain.MessagePublishers;
using Rent.Infra.Data.MessagePublishers;

namespace Rent.Infra.IoC.Externals
{
    public static class MessageIoC
    {
        public static IServiceCollection AddMessageIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMessagePublisher, MessagePublisher>();

            return services;
        }
    }
}

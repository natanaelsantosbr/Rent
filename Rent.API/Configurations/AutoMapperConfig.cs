using AutoMapper;

namespace Rent.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddSingleton((provider) => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] {
                    "Rent.Application"
                });
            }).CreateMapper());

            return services;
        }
    }
}

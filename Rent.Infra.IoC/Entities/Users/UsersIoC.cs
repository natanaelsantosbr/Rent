using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Rent.Application.Abstractions.AppServices.Accounts;
using Rent.Application.Abstractions.AppServices.Users;
using Rent.Application.AppServices.Accounts;
using Rent.Application.AppServices.Users;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;
using Rent.Infra.Data.Identity.Services;
using Rent.Infra.IoC.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Entities.DeliveryMen
{
    public static class UsersIoC
    {
        public static IServiceCollection AddUsersIoC(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserAdminAppService, RegisterUserAdminAppService>();
            services.AddScoped<IRegisterUserDeliveryManAppService, RegisterUserDeliveryManAppService>();

            services.AddScoped<IRegisterAdminService, RegisterAdminService>();
            services.AddScoped<IRegisterDeliveryManService, RegisterDeliveryManService>();

            services.AddScoped<IAuthenticateAppService, AuthenticateAppService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(serviceProvider => ObterUsuarioLogado(serviceProvider));

            return services;
        }

        private static User ObterUsuarioLogado(IServiceProvider serviceProvider)
        {
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
            var identificacao = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier);

            if (identificacao == null)
                return null;

            var scope = serviceProvider.CreateScope();

            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var usuarioRepository = unitOfWork.ObterRepository<User>();

            User usuario = null;

            usuario = usuarioRepository
                    .Consultar().FirstOrDefault(a => a.Id == Guid.Parse(identificacao.Value));

            return usuario;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;

namespace Rent.Infra.Data.Identity.Services
{
    public class RegisterAdminService : IRegisterAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterAdminService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserResultDTO> RegisterAsync(string name, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Name = name,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserType.Admin);
                return new UserResultDTO(Guid.Parse(user.Id));
            }

            var listaErros = new List<string>();

            foreach (var item in result.Errors)
            {
                listaErros.Add(item.Description);
            }

            return new UserResultDTO(listaErros);
        }
    }
}

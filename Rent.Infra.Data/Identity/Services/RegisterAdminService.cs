using Microsoft.AspNetCore.Identity;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<UserResult> Register(string name, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Nome = name,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
                await _signInManager.SignInAsync(user, isPersistent: false);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, TypeUser.Admin);
                return new UserResult(Guid.Parse(user.Id));
            }

            var listaErros = new List<string>();

            foreach (var item in result.Errors)
            {
                listaErros.Add(item.Description);
            }

            return new UserResult(listaErros);
        }
    }
}

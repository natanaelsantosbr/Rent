using Microsoft.AspNetCore.Identity;
using Rent.Domain.Services.Accounts;

namespace Rent.Infra.Data.Identity.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }
    }
}

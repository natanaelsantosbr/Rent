using Microsoft.IdentityModel.Tokens;
using Rent.Application.Abstractions;
using Rent.Domain.Abstractions.Models;
using Rent.Domain.Entities.Users;
using Rent.Domain.Services.Accounts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.IoC.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly IAppSettings _appSettings;

        public TokenService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string Create(User user)
        {
            var role = "deliveryman";

            if (user.IsAdmin)
                role = "admin";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _appSettings.JWT.Issuer,
                audience: _appSettings.JWT.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }
    }
}

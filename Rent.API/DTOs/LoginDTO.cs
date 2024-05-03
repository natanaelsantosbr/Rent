using System.ComponentModel.DataAnnotations;

namespace Rent.API.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

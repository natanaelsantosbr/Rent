using Microsoft.AspNetCore.Identity;

namespace Rent.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreatedAt = DateTime.Now;
        }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

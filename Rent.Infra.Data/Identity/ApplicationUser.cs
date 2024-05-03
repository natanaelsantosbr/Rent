using Microsoft.AspNetCore.Identity;

namespace Rent.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DataDoCadastro = DateTime.Now;
        }
        public string Nome { get; set; }
        public DateTime DataDoCadastro { get; set; }
    }
}

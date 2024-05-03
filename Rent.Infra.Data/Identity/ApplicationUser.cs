using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

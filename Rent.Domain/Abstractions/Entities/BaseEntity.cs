using Rent.Domain.Abstractions.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Entities
{
    public abstract class BaseEntity : Validable
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime DataDoCadastro { get; private set; } = DateTime.Now;
    }
}

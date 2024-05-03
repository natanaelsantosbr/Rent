using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Admin { get; private set; }
        public bool DeliveryMan { get; set; }
        public Guid UserExternalId { get; private set; }
    }
}

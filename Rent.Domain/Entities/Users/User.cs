using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Entities.DeliveryMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        protected User() { }

        public User(string name, string email, Guid userExternalId)
        {
            Name = name;
            Email = email;
            IsAdmin = true;
            IsDeliveryMan = false;
            UserExternalId = userExternalId;
        }

        public User(string name, string email, Guid userExternalId, Guid deliveryManId)
        {
            Name = name;
            Email = email;
            IsAdmin = false;
            IsDeliveryMan = true;
            UserExternalId = userExternalId;
            DeliveryManId = deliveryManId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsDeliveryMan { get; private set; }
        public Guid? DeliveryManId { get; private set; }
        public DeliveryMan? DeliveryMan { get; private set; }
        public Guid UserExternalId { get; private set; }
    }
}

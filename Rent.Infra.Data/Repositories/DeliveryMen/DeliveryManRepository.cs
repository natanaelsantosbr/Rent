using Rent.Domain.Entities.DeliveryMen;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class DeliveryManRepository : Repository<DeliveryMan>, IDeliveryManRepository
    {
        public DeliveryManRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}

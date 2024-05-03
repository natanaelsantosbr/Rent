﻿using Rent.Domain.Entities.DeliveryMen;
using Rent.Domain.Entities.Events;
using Rent.Domain.Entities.MotorcycleRentals;
using Rent.Domain.Entities.Motorcycles;
using Rent.Domain.Entities.Users;
using Rent.Infra.Data.Abstractions;
using Rent.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Repositories.DeliveryMen
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
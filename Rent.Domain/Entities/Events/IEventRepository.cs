﻿using Rent.Domain.Abstractions.Repositories;

namespace Rent.Domain.Entities.Events
{
    public interface IEventRepository : IRepository<Event>
    {
    }
}

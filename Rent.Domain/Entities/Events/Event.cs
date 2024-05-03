using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Entities.Events
{
    public class Event : BaseEntity
    {
        public Event(string details, DateTime createdAt)
        {
            Details = details;
            CreatedAt = createdAt;
        }

        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

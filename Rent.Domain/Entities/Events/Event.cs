using Rent.Domain.Abstractions.Entities;

namespace Rent.Domain.Entities.Events
{
    public class Event : BaseEntity
    {
        protected Event() { }
        public Event(string details, DateTime createdAt)
        {
            Details = details;
            CreatedAt = createdAt;
        }

        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

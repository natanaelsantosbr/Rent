using Rent.Domain.Abstractions.Validations;

namespace Rent.Domain.Abstractions.Entities
{
    public abstract class BaseEntity : Validable
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}

using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Abstractions.Repositories;

namespace Rent.Domain.Abstractions.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> ObterRepository<TEntity>()
           where TEntity : BaseEntity;

        void AbortTransactionAsync();
        Task CommitAsync();
    }
}

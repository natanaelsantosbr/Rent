using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

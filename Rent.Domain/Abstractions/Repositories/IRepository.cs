using Rent.Domain.Abstractions.Entities;
using System.Linq.Expressions;

namespace Rent.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> GetByIdAsync(Guid id);
        public Task<TEntity> GetByIdWithIncludesAsync(Guid id);
        public IQueryable<TEntity> Query();
        public IQueryable<TEntity> QueryWithIncludes();
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(Guid id);
        public void DisableLazyLoading(bool ativar);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

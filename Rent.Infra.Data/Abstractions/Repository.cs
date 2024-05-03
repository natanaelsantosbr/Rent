using Microsoft.EntityFrameworkCore;
using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Abstractions.Repositories;
using Rent.Infra.Data.Context;
using System.Linq.Expressions;

namespace Rent.Infra.Data.Abstractions
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task AddAsync(TEntity entity) => await _db.Set<TEntity>().AddAsync(entity);

        public virtual Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public virtual async void DisableLazyLoading(bool ativar)
        {
            _db.ChangeTracker.LazyLoadingEnabled = ativar;
        }

        public virtual IQueryable<TEntity> Query() => _db.Set<TEntity>().AsQueryable();

        public virtual Task<TEntity> GetByIdAsync(Guid id) => _db.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task DeleteAsync(Guid id)
        {
            var entidade = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entidade);
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var itens = Query().Where(predicate);
            _db.Set<TEntity>().RemoveRange(itens);
        }

        public virtual IQueryable<TEntity> QueryWithIncludes()
        {
            return Query();
        }

        public virtual Task<TEntity> GetByIdWithIncludesAsync(Guid id)
        {
            return QueryWithIncludes()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Repository<TEntity> repository &&
                   EqualityComparer<ApplicationDbContext>.Default.Equals(_db, repository._db);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().AnyAsync(predicate);
        }
    }
}

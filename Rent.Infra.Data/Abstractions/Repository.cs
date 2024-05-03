using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Abstractions.Repositories;
using Rent.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.Abstractions
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task AdicionarAsync(TEntity entity) => await _db.Set<TEntity>().AddAsync(entity);

        public virtual Task AlterarAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public virtual async void DisableLazyLoading(bool ativar)
        {
            _db.ChangeTracker.LazyLoadingEnabled = ativar;
        }

        public virtual IQueryable<TEntity> Consultar() => _db.Set<TEntity>().AsQueryable();

        public virtual Task<TEntity> ConsultarPorIdAsync(Guid id) => _db.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task ExcluirAsync(Guid id)
        {
            var entidade = await ConsultarPorIdAsync(id);
            _db.Set<TEntity>().Remove(entidade);
        }

        public virtual async Task ExcluirAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var itens = Consultar().Where(predicate);
            _db.Set<TEntity>().RemoveRange(itens);
        }

        public virtual IQueryable<TEntity> ConsultarComIncludes()
        {
            return Consultar();
        }

        public virtual Task<TEntity> ConsultarPorIdComIncludesAsync(Guid id)
        {
            return ConsultarComIncludes()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Repository<TEntity> repository &&
                   EqualityComparer<ApplicationDbContext>.Default.Equals(_db, repository._db);
        }

        public Task<bool> ExisteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

using Rent.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> ConsultarPorIdAsync(Guid id);
        public Task<TEntity> ConsultarPorIdComIncludesAsync(Guid id);
        public IQueryable<TEntity> Consultar();
        public IQueryable<TEntity> ConsultarComIncludes();
        public Task AdicionarAsync(TEntity entity);
        public Task AlterarAsync(TEntity entity);
        public Task ExcluirAsync(Guid id);
        public void DisableLazyLoading(bool ativar);
        Task ExcluirAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExisteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

using Rent.Domain.Abstractions.Entities;
using Rent.Domain.Abstractions.Repositories;
using Rent.Domain.Abstractions.UnitsOfWork;
using Rent.Infra.Data.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Infra.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IList _repositories;
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext db)
        {
            _repositories = new ArrayList();
            _db = db;
        }

        public void AbortTransactionAsync()
        {
            _db.ChangeTracker.Clear();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
            _db.ChangeTracker.Clear();
        }

        public IRepository<TEntity> ObterRepository<TEntity>()
            where TEntity : BaseEntity
        {
            var retorno = _repositories.OfType<IRepository<TEntity>>().SingleOrDefault();

            if (retorno == null)
            {
                var assembliesString = new string[]
                {
                    "Rent.Infra.Data"
                };

                var allTypes = new List<Type>();
                foreach (var assemblyString in assembliesString)
                {
                    allTypes.AddRange(Assembly.Load(assemblyString).GetExportedTypes());
                }

                Type[] repositoriosImplementados = (from t in allTypes
                                                    where !t.IsInterface && !t.IsAbstract
                                                    where typeof(IRepository<TEntity>).IsAssignableFrom(t)
                                                    select t)
                                                    .ToArray();

                if (repositoriosImplementados.Length > 0)
                {
                    IRepository<TEntity>[] instantiatedTypes = repositoriosImplementados
                        .Select(typeRepo => (IRepository<TEntity>)Activator.CreateInstance(typeRepo, _db))
                        .ToArray();

                    retorno = instantiatedTypes.SingleOrDefault();
                    _repositories.Add(retorno);
                }
            }

            return retorno;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

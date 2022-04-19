using BuildingSiteManagementWebApp.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuildingSiteManagementWebApp.Data.Repository.Abstracts
{
    public interface IRepository<T> : IDisposable where T : class, IEntity
    {
        ApplicationDbContext Context { get; }

        void Create(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> filter);

        Task CommitAsync();
    }
}

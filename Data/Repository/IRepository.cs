using BuildingSiteManagementWebApp.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BuildingSiteManagementWebApp.Data.Repository.Abstracts
{
    public interface IRepository<T> : IDisposable where T : class, IEntity
    {

        void Create(T entity);
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> filter);

        ApplicationDbContext Context { get; }
        void Commit();
    }
}

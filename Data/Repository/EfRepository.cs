using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BuildingSiteManagementWebApp.Data.Repository.Concretes
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {
        public ApplicationDbContext Context { get; }

        public EfRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return Context.Set<T>().AsQueryable();
            return Context.Set<T>().Where(filter);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            var entity = Context.Entry(filter);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}

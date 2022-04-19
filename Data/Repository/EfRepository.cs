using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Data.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> q = Context.Set<T>();
            if (includes is not null && includes.Count() > 0)
            {
                foreach (var obj in includes)
                {
                    q = q.Include(obj);
                }
            }

            return await q.SingleOrDefaultAsync(filter);

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> q = Context.Set<T>();
            if (includes is not null && includes.Count() > 0)
            {
                foreach (var obj in includes)
                {
                    q = q.Include(obj);
                }
            }
            if (filter == null)
                return q;
            return q.Where(filter);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var entity =await Context.Set<T>().SingleOrDefaultAsync(filter);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}

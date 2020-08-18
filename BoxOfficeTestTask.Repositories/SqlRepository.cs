using BoxOfficeTestTask.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Repositories
{
    public abstract class SqlRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> EfDbSet;

        protected SqlRepository(ApplicationDbContext context)
        {
            Context = context;
            EfDbSet = context.Set<T>();
        }

        public Task<int> AddAsync(T entity)
        {
            EfDbSet.Add(entity);
            return Context.SaveChangesAsync();
        }

        public Task<int> AddRangeAsync(IEnumerable<T> enitites)
        {
            EfDbSet.AddRange(enitites);
            return Context.SaveChangesAsync();
        }

        

        public virtual IQueryable<T> GetAllAsync()
        {
            return (IOrderedQueryable<T>)EfDbSet;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return EfDbSet.Where(predicate);
        }

        public abstract Task<T> GetById(object id);

        public Task<int> RemoveAsync(T entity)
        {
            EfDbSet.Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task<int> RemoveRangeAsync(IEnumerable<T> entities)
        {
            EfDbSet.RemoveRange(entities);
            return Context.SaveChangesAsync();
        }

        public Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return EfDbSet.SingleOrDefaultAsync(predicate);
        }

        public Task<int> UpdateAsync(T entity)
        {
            EfDbSet.Update(entity);
            return Context.SaveChangesAsync();
        }
    }
}

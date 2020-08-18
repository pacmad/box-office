using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetById(object id);

        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> enitites);

        Task<int> UpdateAsync(T entity);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        Task<int> RemoveAsync(T entity);
        Task<int> RemoveRangeAsync(IEnumerable<T> entities);

        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);

    }
}

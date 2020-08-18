using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Repositories.Queries
{
    public static class IQueryableExtensions
    {
        public static async Task<IPagedEnumerable<T>> ToPagedEnumerableAsync<T>(this IQueryable<T> source, int page, int size) where T : class, new()
        {
            var count = await source.CountAsync();
            source = source.Skip((page - 1) * size).Take(size);
            var items = await source.ToListAsync();
            return new PagedResult<T>(items, count, page, count / size + 1, size);
        }

        public static IPagedEnumerable<T> ToPagedEnumerable<T>(this IEnumerable<T> source, int page, int size, int count) where T : class, new()
        {
            return new PagedResult<T>(source.Skip((page - 1) * size).Take(size), count, page, count / size + 1, size);
        }

        public static IPagedEnumerable<T> ToPagedEnumerable<T>(this IEnumerable<T> source, int page, int size) where T : class, new()
        {
            var count = source.Count();
            return new PagedResult<T>(source.Skip((page - 1) * size).Take(size), count, page, count / size + 1, size);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, Expression<Func<T, object>> keySelector, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Unspecified:
                case SortOrder.Ascending:
                    return source.OrderBy(keySelector);
                case SortOrder.Descending:
                    return source.OrderByDescending(keySelector);
                default:
                    return source.OrderBy(keySelector);
            }
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, Expression<Func<T, object>> keySelector, SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Unspecified:
                case SortOrder.Ascending:
                    return source.ThenBy(keySelector);
                case SortOrder.Descending:
                    return source.ThenByDescending(keySelector);
                default:
                    return source;
            }
        }
    }
}

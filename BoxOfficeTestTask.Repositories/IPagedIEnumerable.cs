using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfficeTestTask.Repositories
{
    public interface IPagedEnumerable<out TEntity> : IEnumerable<TEntity>
    {
        IEnumerable<TEntity> Items { get; }

        int TotalCount { get; }

        int CurrentPage { get; }

        int PageCount { get; }

        int PageSize { get; }
    }
}

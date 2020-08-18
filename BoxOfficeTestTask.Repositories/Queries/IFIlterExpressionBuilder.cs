using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BoxOfficeTestTask.Repositories.Queries
{
    public interface IFilterExpressionBuilder<in TQuery, T> where TQuery : Query<T>
                                                            where T : class, new()
    {
        Expression<Func<T, bool>> BuildWhere(TQuery query);

        Expression<Func<T, object>> BuildOrderBy(TQuery query);
    }
}

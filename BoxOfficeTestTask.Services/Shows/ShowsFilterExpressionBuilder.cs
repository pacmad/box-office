using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BoxOfficeTestTask.Services.Shows
{
    public class ShowsFilterExpressionBuilder : IFilterExpressionBuilder<ShowsQuery, Show>
    {
        public Expression<Func<Show, object>> BuildOrderBy(ShowsQuery query)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Show, bool>> BuildWhere(ShowsQuery query)
        {
            Expression<Func<Show, bool>> result = null;


            result = result.ValidatedAndAlso(query.Query, x => EF.Functions.Like(x.Name, $"%{query.Query}%"));
            result = result.ValidatedAndAlso(query.StartDate, x => x.Sessions.Min(x => x.StartTime) > query.StartDate);

            if (result == null)
                return x => true;

            return result;
        }
    }
}

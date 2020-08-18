using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.Repositories.Queries;
using System;

namespace BoxOfficeTestTask.Services.Shows
{
    public class ShowsQuery : Query<Show>
    {
        public string Query { get; set; }

        public DateTime? StartDate { get; set; }
    }
}

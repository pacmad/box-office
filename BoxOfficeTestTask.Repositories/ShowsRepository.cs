using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Repositories
{
    public class ShowsRepository : SqlRepository<Show>, IShowsRepository
    {
        public ShowsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Show> GetById(object id)
        {
            return EfDbSet
                .Include(x => x.Sessions)
                .FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        public override IQueryable<Show> GetAllAsync()
        {
            return EfDbSet
                .Include(x => x.Sessions)
                .AsNoTracking();
        }
    }
}

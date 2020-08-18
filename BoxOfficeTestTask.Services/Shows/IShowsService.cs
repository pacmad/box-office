using BoxOfficeTestTask.Models.Shows;
using System.Linq;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Services.Shows
{
    public interface IShowsService
    {
        Task<Show> AddAsync(Show show);

        IQueryable<Show> GetAsync(ShowsQuery query);

        IQueryable<Show> GetAll();

        Task<Show> GetById(int id);
    }
}
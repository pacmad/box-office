using BoxOfficeTestTask.Models.Shows;
using BoxOfficeTestTask.Repositories;
using BoxOfficeTestTask.Repositories.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BoxOfficeTestTask.Services.Shows
{
    public class ShowsService : IShowsService
    {
        private readonly IShowsRepository _showsRepository;
        private readonly IFilterExpressionBuilder<ShowsQuery, Show> _expressionBuilder;

        public ShowsService(IShowsRepository showsRepository,
            IFilterExpressionBuilder<ShowsQuery, Show> expressionBuilder)
        {
            _showsRepository = showsRepository ?? throw new ArgumentNullException(nameof(showsRepository));
            _expressionBuilder = expressionBuilder ?? throw new ArgumentNullException(nameof(expressionBuilder));
        }

        public async Task<Show> AddAsync(Show show)
        {
            try
            {
                if(await _showsRepository.AddAsync(show) > 0)
                    return show;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public async Task<bool> UpdateAsync(Show show)
        {
            try
            {
                var currentShow =await _showsRepository.SingleOrDefault(x => x.Id == show.Id);

                if (currentShow == null)
                    return false;

                currentShow.Name = show.Name;
                currentShow.MinAge = show.MinAge;
                currentShow.DurationInMinutes = show.DurationInMinutes;
                currentShow.Description = show.Description;

                return await _showsRepository.UpdateAsync(currentShow) > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var currentShow = await _showsRepository.SingleOrDefault(x => x.Id == id);

                if (currentShow == null)
                    return false;

                return await _showsRepository.RemoveAsync(currentShow) > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<Show> GetById(int id)
        {
            try
            {
                return await _showsRepository.GetById(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public IQueryable<Show> GetAsync(ShowsQuery query)
        {
            try
            {
                return _showsRepository.Get(_expressionBuilder.BuildWhere(query));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public IQueryable<Show> GetAll()
        {
            try
            {
                return _showsRepository.GetAllAsync();
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}

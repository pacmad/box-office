using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BoxOfficeTestTask.Repositories.Queries;
using BoxOfficeTestTask.Services.Shows;
using BoxOfficeTestTask.ViewModels.Shows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoxOfficeTestTask.Controllers
{
    [ApiController]
    [Route("api/shows")]
    public class ShowsController : Controller
    {
        private readonly IShowsService _showsService;
        private readonly IMapper _mapper;

        public ShowsController(IShowsService showsService,IMapper mapper)
        {
            _showsService = showsService ?? throw new ArgumentNullException(nameof(showsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery]string query,
            [FromQuery]DateTime? startDate,
            [FromQuery]int? page)
        {
            var showsResult = _showsService.GetAsync(new ShowsQuery
            {
                Query = query,
                StartDate = startDate
            });



            return Ok(await _mapper.ProjectTo<ShowViewModel>(showsResult)
                .ToPagedEnumerableAsync(page ?? 1, 10));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var show = await _showsService.GetById(id);

            if (show == null)
                return NotFound();

            return Ok(_mapper.Map<ShowViewModel>(show));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Set(ShowViewModel model)
        {
            var show = await _showsService.AddAsync(new Models.Shows.Show
            {
                Description = model.Description,
                DurationInMinutes = model.DurationInMinutes,
                MinAge = model.MinAge,
                Name = model.Name,
                Sessions = model.Sessions.Select(x => new Models.Shows.Session
                {
                    MaxTickets = x.MaxTickets,
                    StartTime = x.StartTime
                }).ToList()
            });

            if (show != null)
                return Ok(_mapper.Map<ShowViewModel>(show));

            return BadRequest();
        }


    }
}
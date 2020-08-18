using System;
using AutoMapper;
using BoxOfficeTestTask.Services.Shows;
using BoxOfficeTestTask.ViewModels.Shows;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoxOfficeTestTask.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IShowsService _showsService;
        private readonly IMapper _mapper;

        public DashboardController(IShowsService showsService,
            IMapper mapper)
        {
            _showsService = showsService ?? throw new ArgumentNullException(nameof(showsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public IActionResult List()
        {
            var shows = _mapper.ProjectTo<ShowViewModel>(_showsService.GetAll());
            return Ok(shows);
        }
    }
}
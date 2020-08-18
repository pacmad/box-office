using System;
using BoxOfficeTestTask.Services.Users;
using BoxOfficeTestTask.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BoxOfficeTestTask.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel model)
        {
            var authResult = _userService.Authenticate(model.Login, model.Password);

            if (authResult != null)
                return Ok(new LoginResultViewModel
                {
                    Id = authResult.User.Id,
                    Login = authResult.User.Login,
                    Role = authResult.User.Role,
                    Token = authResult.Token
                });

            return BadRequest("Incorrect login or password");
        }
    }
}
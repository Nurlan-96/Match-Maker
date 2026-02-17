using MatchMaker.Application.Command.UserCommands;
using MatchMaker.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _authService.LoginAsync(command);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await _authService.RegisterAsync(command);
            return Ok();
        }
    }

}

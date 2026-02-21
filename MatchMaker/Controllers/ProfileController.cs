using MatchMaker.Application.Command.UserCommands;
using MatchMaker.Application.Services.User;
using MatchMaker.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatchMaker.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public ProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost("me/media")]
        public async Task<IActionResult> AddMedia(AddUserMediaCommand command)
        {
            var userId = User.GetUserId();
            await _userProfileService.AddMediaAsync(userId, command);
            return Ok();
        }
    }
}

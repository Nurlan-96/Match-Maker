using MatchMaker.Application.Auth;
using MatchMaker.Application.Command.UserCommands;
using MatchMaker.Application.Services.User;
using MatchMaker.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace MatchMaker.Infrastructure.Services.Auth
{
    public class AuthService(UserManager<ApplicationUser> userManager, IUserProfileService profileService, IJwtTokenService jwt
) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IUserProfileService _profileService;
        private readonly IJwtTokenService _jwt = jwt;
        public async Task RegisterAsync(RegisterUserCommand command)
        {
            if (command.Password != command.ConfirmPassword)
                throw new InvalidOperationException("Passwords do not match.");

            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email
            };

            var result = await _userManager.CreateAsync(
                user,
                command.Password
            );

            if (!result.Succeeded)
                throw new InvalidOperationException(
                    string.Join("; ", result.Errors.Select(e => e.Description))
                );

            await _profileService.CreateProfileAsync(user.Id);
        }

        public async Task<string> LoginAsync(LoginUserCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null)
                throw new UnauthorizedAccessException();

            if (!await _userManager.CheckPasswordAsync(user, command.Password))
                throw new UnauthorizedAccessException();

            if (user.IsBanned)
                throw new UnauthorizedAccessException("User is banned.");

            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return _jwt.GenerateToken(user.Id, user.Email!);
        }
    }
}

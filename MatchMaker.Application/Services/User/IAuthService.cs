using MatchMaker.Application.Command.UserCommands;

namespace MatchMaker.Application.Services.User
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserCommand command);
        Task<string> LoginAsync(LoginUserCommand command);

    }
}

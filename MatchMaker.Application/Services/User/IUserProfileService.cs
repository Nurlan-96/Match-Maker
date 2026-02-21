using MatchMaker.Application.Command.UserCommands;

namespace MatchMaker.Application.Services.User
{
    public interface IUserProfileService
    {
        Task CreateProfileAsync(Guid userId);
        Task AddMediaAsync(Guid userId, AddUserMediaCommand command);

    }
}

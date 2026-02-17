namespace MatchMaker.Application.Services.User
{
    public interface IUserProfileService
    {
        Task CreateProfileAsync(Guid userId);

    }
}

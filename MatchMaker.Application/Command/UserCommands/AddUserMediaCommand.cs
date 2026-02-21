using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Command.UserCommands
{
    public record AddUserMediaCommand(
    string ExternalMediaId,
    MediaCategory Category,
    string Title,
    string? ImageUrl,
    int Rank
);
}

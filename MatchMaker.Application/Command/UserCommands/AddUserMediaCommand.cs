using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Command.UserCommands
{
    public record AddUserMediaCommand(
     string ExternalMediaId,
     MediaCategory Category,
     int Rank
 );
}

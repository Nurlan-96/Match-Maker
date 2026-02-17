namespace MatchMaker.Application.Command.UserCommands
{
    public record LoginUserCommand(
     string Email,
     string Password
 );
}

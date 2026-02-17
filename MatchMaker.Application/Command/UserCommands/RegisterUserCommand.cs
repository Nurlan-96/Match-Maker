namespace MatchMaker.Application.Command.UserCommands
{
    public record RegisterUserCommand(
    string Email,
    string Password,
    string ConfirmPassword
);
}

namespace MatchMaker.Application.Command.UserCommands
{
    public class ChangeEmailCommand
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
        public string Password { get; set; }
    }
}

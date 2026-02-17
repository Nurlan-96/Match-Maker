using System;
using System.Collections.Generic;
using System.Text;

namespace MatchMaker.Application.Command.UserCommands
{
    public class ChangePasswordCommand
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

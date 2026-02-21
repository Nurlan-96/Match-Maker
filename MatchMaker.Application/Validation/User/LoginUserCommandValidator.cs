using FluentValidation;
using MatchMaker.Application.Command.UserCommands;

namespace MatchMaker.Application.Validation.User
{
    public class LoginUserCommandValidator
     : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

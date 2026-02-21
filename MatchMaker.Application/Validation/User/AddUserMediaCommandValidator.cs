using FluentValidation;
using MatchMaker.Application.Command.UserCommands;

namespace MatchMaker.Application.Validation.User
{
    public class AddUserMediaCommandValidator
    : AbstractValidator<AddUserMediaCommand>
    {
        public AddUserMediaCommandValidator()
        {
            RuleFor(x => x.ExternalMediaId)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Rank)
                .InclusiveBetween(1, 10);
        }
    }
}

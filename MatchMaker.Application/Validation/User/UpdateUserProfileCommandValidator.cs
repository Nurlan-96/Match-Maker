using FluentValidation;
using MatchMaker.Application.Command.UserCommands;
using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Validation.User
{
    public class UpdateUserProfileCommandValidator
    : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(x => x.Gender)
                .NotEqual(GenderEnum.Unspecified)
                .WithMessage("Gender must be selected.");

            RuleFor(x => x.InterestedIn)
                .Must(x => x != InterestedGenderEnum.None)
                .WithMessage("At least one interested gender must be selected.");

            RuleFor(x => x.HeightCm)
                .GreaterThan(100)
                .LessThan(250)
                .WithMessage("Height must be between 100 and 250 cm.");

            RuleFor(x => x.WeightKg)
                .GreaterThan(30)
                .LessThan(300)
                .WithMessage("Weight must be between 30 and 300 kg.");

            RuleFor(x => x.Bio)
                .MaximumLength(500);
        }
    }
}

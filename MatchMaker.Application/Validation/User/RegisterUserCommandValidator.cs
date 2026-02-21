using FluentValidation;
using MatchMaker.Application.Command.UserCommands;

namespace MatchMaker.Application.Validation.User
{
    public class RegisterUserCommandValidator
    : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Must(ContainUppercase)
                .WithMessage("Password must contain at least one uppercase letter.")
            .Must(ContainLowercase)
                .WithMessage("Password must contain at least one lowercase letter.")
            .Must(ContainDigit)
                .WithMessage("Password must contain at least one digit.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
        private static bool ContainUppercase(string password) =>
    password.Any(char.IsUpper);

        private static bool ContainLowercase(string password) =>
            password.Any(char.IsLower);

        private static bool ContainDigit(string password) =>
            password.Any(char.IsDigit);
    }
}

using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Command.UserCommands
{
    public record UpdateUserProfileCommand(
    GenderEnum Gender,
    InterestedGenderEnum InterestedIn,
    decimal HeightCm,
    int WeightKg,
    string Bio
);
}

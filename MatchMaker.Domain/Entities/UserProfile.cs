using MatchMaker.Domain.Enums;
using System.Reflection;

namespace MatchMaker.Domain.Entities
{
    public class UserProfile
    {
        // PK = FK to Identity user
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal HeightCm { get; set; }
        public int WeightKg { get; set; }
        public GenderEnum Gender { get; set; }
        public InterestedGenderEnum InterestedIn { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace MatchMaker.Infrastructure.Identity
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public DateOnly BirthDate { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public DateTime? LastLoginAt { get; set; }
    }
}

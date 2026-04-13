
namespace MatchMaker.Domain.Entities
{
    public class UserMediaRank
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
        public MediaEntity Media { get; set; } = null!;
        public int Rank { get; set; }
    }
}

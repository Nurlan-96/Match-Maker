
namespace MatchMaker.Domain.Entities
{
    public class UserMediaRank
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int MediaId { get; set; }
        public MediaEntity Media { get; set; } = null!;
        public int Rank { get; set; }
    }
}

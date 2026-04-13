using MatchMaker.Domain.Enums;

namespace MatchMaker.Domain.Entities
{
    
        public class MediaEntity
        {
            public Guid Id { get; set; }

            // External API ID (IMDb, Google Books, Spotify)
            public string ExternalId { get; set; } = null!;

            public MediaCategory Category { get; set; }

            public string Title { get; set; } = null!;

            public string? ImageUrl { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public ICollection<UserMediaRank> UserRanks { get; set; }
                = new List<UserMediaRank>();
        }
    }

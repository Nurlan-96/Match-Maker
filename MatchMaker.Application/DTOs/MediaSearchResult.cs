namespace MatchMaker.Application.DTOs
{
    public class MediaSearchResult
    {
        public string ExternalId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Year { get; set; }
        public string? ImdbUrl { get; set; }
    }
}

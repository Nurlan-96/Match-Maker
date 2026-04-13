namespace MatchMaker.Application.DTOs
{
    public class MediaDetails
    {
        public string ExternalId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int? Year { get; set; }
    }
}

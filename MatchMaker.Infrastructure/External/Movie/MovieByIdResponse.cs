namespace MatchMaker.Infrastructure.External.Movie
{
    public class MovieByIdResponse
    {
        public string Id { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string Image { get; set; } = default!;

        public string? Year { get; set; }
    }
}

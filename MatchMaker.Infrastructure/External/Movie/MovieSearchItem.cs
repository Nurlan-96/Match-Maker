using System.Text.Json.Serialization;

namespace MatchMaker.Infrastructure.External.Movie
{
    public class MovieSearchItem
    {
        [JsonPropertyName("#TITLE")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("#YEAR")]
        public int? Year { get; set; }

        [JsonPropertyName("#IMDB_ID")]
        public string ImdbId { get; set; } = null!;

        [JsonPropertyName("#IMG_POSTER")]
        public string? Poster { get; set; }

        [JsonPropertyName("#IMDB_URL")]
        public string? ImdbUrl { get; set; }
    }
}

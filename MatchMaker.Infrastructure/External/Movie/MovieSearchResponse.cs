using System.Text.Json.Serialization;

namespace MatchMaker.Infrastructure.External.Movie
{
    public class MovieSearchResponse
    {
        [JsonPropertyName("description")]
        public List<MovieSearchItem> Description { get; set; } = new();
    }
}

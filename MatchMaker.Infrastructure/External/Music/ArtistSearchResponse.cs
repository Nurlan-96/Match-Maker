using System.Text.Json.Serialization;

namespace MatchMaker.Infrastructure.External.Music
{
    public class ArtistSearchResponse
    {
        [JsonPropertyName("artists")]
        public List<ArtistSearchItem>? Artists { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MatchMaker.Infrastructure.External.Music
{
    public class ArtistSearchItem
    {
        [JsonPropertyName("idArtist")]
        public string IdArtist { get; set; } = null!;

        [JsonPropertyName("strArtist")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("strArtistThumb")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("intFormedYear")]
        public string? FormedYear { get; set; }
    }
}

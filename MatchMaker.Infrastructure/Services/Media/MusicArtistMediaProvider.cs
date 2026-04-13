using MatchMaker.Application.DTOs;
using MatchMaker.Application.Services.Media;
using MatchMaker.Domain.Enums;
using MatchMaker.Infrastructure.External.Music;
using System.Net.Http.Json;

namespace MatchMaker.Infrastructure.Services.Media
{
    public class MusicArtistMediaProvider : IMediaProvider
    {
        private readonly HttpClient _http;

        public MusicArtistMediaProvider(HttpClient http)
        {
            _http = http;
        }
        public bool CanHandle(MediaCategory category)
        {
            return category == MediaCategory.Music;
        }

        public async Task<MediaSearchResult?> GetByExternalIdAsync(string externalId, MediaCategory category)
        {
            if (category != MediaCategory.Music)
                throw new NotSupportedException();

            var response = await _http.GetFromJsonAsync<ArtistSearchResponse>(
                $"https://www.theaudiodb.com/api/v1/json/2/artist.php?i={externalId}");

            var artist = response?.Artists?.FirstOrDefault();

            if (artist == null)
                return null;

            return new MediaSearchResult
            {
                ExternalId = artist.IdArtist,
                Title = artist.Name,
                ImageUrl = artist.ImageUrl,
                Year = artist.FormedYear
            };
        }

        public async Task<List<MediaSearchResult>> SearchAsync(string query, MediaCategory category)
        {
            if (category != MediaCategory.Music)
                throw new NotSupportedException("MusicArtistMediaProvider only supports MusicArtist");

            var response = await _http.GetFromJsonAsync<ArtistSearchResponse>(
                $"https://www.theaudiodb.com/api/v1/json/2/search.php?s={query}");

            if (response?.Artists == null)
                return new List<MediaSearchResult>();

            return response.Artists.Select(x => new MediaSearchResult
            {
                ExternalId = x.IdArtist,
                Title = x.Name,
                ImageUrl = x.ImageUrl,
                Year = x.FormedYear,
            }).ToList();
        }
    }
}

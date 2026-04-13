using MatchMaker.Application.DTOs;
using MatchMaker.Application.Services.Media;
using MatchMaker.Domain.Enums;
using MatchMaker.Infrastructure.External.Movie;
using System.Net.Http.Json;

namespace MatchMaker.Infrastructure.Services.Media
{
    public class MovieMediaProvider : IMediaProvider
    {
        private readonly HttpClient _http;

        public MovieMediaProvider(HttpClient http)
        {
            _http = http;
        }
        public bool CanHandle(MediaCategory category)
        {
            return category == MediaCategory.Movies ||
                   category == MediaCategory.Shows;
        }

        public async Task<MediaSearchResult?> GetByExternalIdAsync(string externalId, MediaCategory category)
        {
            var response = await _http.GetFromJsonAsync<MovieSearchResponse>(
                $"https://imdb.iamidiotareyoutoo.com/search?q={externalId}");

            var item = response?.Description?
                .FirstOrDefault(x => x.ImdbId == externalId);

            if (item == null)
                return null;

            return new MediaSearchResult
            {
                ExternalId = item.ImdbId,
                Title = item.Title,
                ImageUrl = item.Poster,
                Year = item.Year?.ToString(),
                ImdbUrl = item.ImdbUrl
            };
        }

        public async Task<List<MediaSearchResult>> SearchAsync(string query, MediaCategory category)
        {
            var encodedQuery = Uri.EscapeDataString(query);

            var response = await _http.GetFromJsonAsync<MovieSearchResponse>(
                $"https://imdb.iamidiotareyoutoo.com/search?q={encodedQuery}");

            if (response?.Description == null)
                return new List<MediaSearchResult>();

            return response.Description
            .Select(x => new MediaSearchResult
            {
            ExternalId = x.ImdbId,
            Title = x.Title,
            ImageUrl = x.Poster,
            Year = x.Year?.ToString(),
            ImdbUrl = x.ImdbUrl
            })
            .ToList();
        }
    }
}
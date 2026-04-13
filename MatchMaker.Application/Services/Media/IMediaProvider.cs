using MatchMaker.Application.DTOs;
using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Services.Media
{
    public interface IMediaProvider
    {
        bool CanHandle(MediaCategory category);

        Task<List<MediaSearchResult>> SearchAsync(string query, MediaCategory category);
        Task<MediaSearchResult?> GetByExternalIdAsync(string externalId, MediaCategory category);
    }
}

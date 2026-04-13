using MatchMaker.Domain.Enums;

namespace MatchMaker.Application.Services.Media
{
    public interface IMediaProviderFactory
    {
        IMediaProvider GetProvider(MediaCategory category);
    }
}

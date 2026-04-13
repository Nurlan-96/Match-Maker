using MatchMaker.Application.Services.Media;
using MatchMaker.Domain.Enums;

namespace MatchMaker.Infrastructure.Services.Media
{
    public class MediaProviderFactory : IMediaProviderFactory
    {
        private readonly IEnumerable<IMediaProvider> _providers;

        public MediaProviderFactory(IEnumerable<IMediaProvider> providers)
        {
            _providers = providers;
        }

        public IMediaProvider GetProvider(MediaCategory category)
        {
            var provider = _providers.FirstOrDefault(p => p.CanHandle(category));

            if (provider == null)
                throw new InvalidOperationException($"No provider found for {category}");

            return provider;
        }
    }
}

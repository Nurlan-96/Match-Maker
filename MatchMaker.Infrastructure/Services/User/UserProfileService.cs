using MatchMaker.Application.Command.UserCommands;
using MatchMaker.Application.Services.Media;
using MatchMaker.Application.Services.User;
using MatchMaker.Domain.Entities;
using MatchMaker.Domain.Enums;
using MatchMaker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MatchMaker.Infrastructure.Services.User
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext _context;
        private readonly IMediaProviderFactory _mediaProviderFactory;

        public UserProfileService(
            AppDbContext context,
            IMediaProviderFactory mediaProviderFactory)
        {
            _context = context;
            _mediaProviderFactory = mediaProviderFactory;
        }

        public async Task CreateProfileAsync(Guid userId)
        {
            var exists = await _context.UserProfiles
                .AnyAsync(p => p.UserId == userId);

            if (exists)
                return;

            _context.UserProfiles.Add(new UserProfile
            {
                UserId = userId,
                Gender = GenderEnum.Unspecified,
                InterestedIn = InterestedGenderEnum.None
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddMediaAsync(Guid userId, AddUserMediaCommand command)
        {
            var media = await _context.MediaEntities
                .FirstOrDefaultAsync(m =>
                    m.ExternalId == command.ExternalMediaId &&
                    m.Category == command.Category);

            var count = await _context.UserMediaRanks
                .CountAsync(x =>
                    x.UserId == userId &&
                    x.Media.Category == command.Category);

            if (count >= 10)
                throw new InvalidOperationException("You can only have 10 items per category.");

            if (media != null)
            {
                var alreadyExists = await _context.UserMediaRanks
                    .AnyAsync(x =>
                        x.UserId == userId &&
                        x.MediaId == media.Id);

                if (alreadyExists)
                    throw new InvalidOperationException("This media is already in your list.");
            }

            var rankExists = await _context.UserMediaRanks
                .AnyAsync(x =>
                    x.UserId == userId &&
                    x.Rank == command.Rank &&
                    x.Media.Category == command.Category);

            if (rankExists)
                throw new InvalidOperationException("This rank is already used in this category.");

            if (media == null)
            {
                var provider = _mediaProviderFactory.GetProvider(command.Category);

                var result = await provider.GetByExternalIdAsync(
                    command.ExternalMediaId,
                    command.Category);

                if (result == null)
                    throw new InvalidOperationException("Media not found.");

                media = new MediaEntity
                {
                    ExternalId = result.ExternalId,
                    Category = command.Category,
                    Title = result.Title,
                    ImageUrl = result.ImageUrl
                };

                _context.MediaEntities.Add(media);
            }

            _context.UserMediaRanks.Add(new UserMediaRank
            {
                UserId = userId,
                Media = media,
                Rank = command.Rank
            });

            await _context.SaveChangesAsync();
        }
    }
}
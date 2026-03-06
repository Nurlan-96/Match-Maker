using MatchMaker.Application.Command.UserCommands;
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

        public UserProfileService(AppDbContext context)
        {
            _context = context;
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

        public async Task AddMediaAsync(
        Guid userId,
        AddUserMediaCommand command)
        {
            var media = await _context.MediaEntities
                .FirstOrDefaultAsync(m =>
                    m.ExternalId == command.ExternalMediaId &&
                    m.Category == command.Category);

            if (media == null)
            {
                media = new MediaEntity
                {
                    ExternalId = command.ExternalMediaId,
                    Category = command.Category,
                    Title = command.Title,
                    ImageUrl = command.ImageUrl
                };

                _context.MediaEntities.Add(media);
                await _context.SaveChangesAsync();
            }

            var count = await _context.UserMediaRanks
                .CountAsync(x =>
                x.UserId == userId &&
            _context.MediaEntities
            .Where(m => m.Category == command.Category)
            .Select(m => m.Id)
            .Contains(x.MediaId));

            if (count >= 10)
                throw new InvalidOperationException(
                    "You can only have 10 items per category.");

            var exists = await _context.UserMediaRanks
                .AnyAsync(x =>
                    x.UserId == userId &&
                    x.MediaId == media.Id);

            if (exists)
                throw new InvalidOperationException(
                    "This media is already in your list.");

            _context.UserMediaRanks.Add(new UserMediaRank
            {
                UserId = userId,
                MediaId = media.Id,
                Rank = command.Rank
            });

            await _context.SaveChangesAsync();
        }
    }
}

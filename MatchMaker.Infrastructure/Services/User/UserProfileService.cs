using Microsoft.EntityFrameworkCore;
using MatchMaker.Application.Services.User;
using MatchMaker.Domain.Entities;
using MatchMaker.Domain.Enums;
using MatchMaker.Infrastructure.Data;

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
    }
}

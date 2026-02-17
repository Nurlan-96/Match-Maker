using MatchMaker.Infrastructure.Identity;
using MatchMaker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatchMaker.Infrastructure.Data;

public class AppDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<MediaEntity> MediaEntities => Set<MediaEntity>();
    public DbSet<UserMediaRank> UserMediaRanks => Set<UserMediaRank>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(p => p.UserId);

            entity.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<UserProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<UserMediaRank>(entity =>
        {
            entity.HasIndex(x => new { x.UserId, x.MediaId })
                .IsUnique();

            entity.ToTable(t =>
                t.HasCheckConstraint(
                    "CK_UserMediaRank_Rank",
                    "\"Rank\" BETWEEN 1 AND 10"
                ));
        });
    }
}

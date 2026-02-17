using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MatchMaker.Infrastructure.Data
{
    public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args) =>
            new(new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=matchmaker;Username=matchmaker;Password=matchmaker")
                .Options);
    }
}

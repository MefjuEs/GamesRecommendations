using Microsoft.EntityFrameworkCore;

namespace MAG.Database
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>().HasKey(r => new
            {
                r.GameId,
                r.UserId
            });

            builder.Entity<GameGenre>().HasKey(r => new
            {
                r.GameId,
                r.GenreId,
            });

            builder.Entity<GamePlatform>().HasKey(r => new
            {
                r.GameId,
                r.PlatformId
            });

            builder.Entity<Game>().HasIndex(m => m.Title).IsUnique();
        }
    }
}

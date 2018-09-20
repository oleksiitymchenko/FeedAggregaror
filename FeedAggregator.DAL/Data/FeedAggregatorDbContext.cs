using FeedAggregator.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedAggregator.DAL.Data
{
    public class FeedAggregatorDbContext : DbContext
    {
        public DbSet<UserCollection> UserCollections { get; set; }
        public DbSet<Feed> FeedCollections { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }

        public FeedAggregatorDbContext(DbContextOptions<FeedAggregatorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCollection>()
                        .HasMany(o => o.FeedCollections)
                        .WithOne(c => c.UserCollection)
                        .IsRequired();

            modelBuilder.Entity<Feed>()
                        .HasMany(o => o.FeedItems)
                        .WithOne(c => c.FeedCollection)
                        .IsRequired();

            modelBuilder.Seed();
        }
    }
}

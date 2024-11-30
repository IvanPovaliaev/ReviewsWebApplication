using Microsoft.EntityFrameworkCore;
using Reviews.Domain.Helper;
using Reviews.Domain.Models;

namespace Reviews.Domain
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Login> Logins { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                        .HasOne(p => p.Rating)
                        .WithMany(t => t.Reviews)
                        .HasForeignKey(p => p.RatingId)
                        .OnDelete(DeleteBehavior.Cascade);

            var reviews = Initialization.SetFeedbacks();
            var ratings = Initialization.SetRatings();

            modelBuilder.Entity<Review>()
                        .HasData(reviews);

            modelBuilder.Entity<Rating>()
                        .HasData(ratings);

            var login = Initialization.SetLogins();
            modelBuilder.Entity<Login>()
                        .HasData(login);
        }
    }
}

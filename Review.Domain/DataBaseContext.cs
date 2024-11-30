using Microsoft.EntityFrameworkCore;
using Review.Domain.Helper;
using Review.Domain.Models;

namespace Review.Domain
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                        .HasOne(p => p.Rating)
                        .WithMany(t => t.Feedbacks)
                        .HasForeignKey(p => p.RatingId)
                        .OnDelete(DeleteBehavior.Cascade);

            var Feedbacks = Initialization.SetFeedbacks();
            var Rating = Initialization.SetRatings();

            modelBuilder.Entity<Feedback>()
                        .HasData(Feedbacks);

            modelBuilder.Entity<Rating>()
                        .HasData(Rating);

            var login = Initialization.SetLogins();
            modelBuilder.Entity<Login>()
                        .HasData(login);
        }
    }
}

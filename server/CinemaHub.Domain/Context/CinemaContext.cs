using CinemaHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaHub.Domain.Context
{
    public class CinemaContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Seed();
            base.OnModelCreating(builder);
        }
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Cinema> Cinemas => Set<Cinema>();
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Hall> Halls => Set<Hall>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Screening> Screenings => Set<Screening>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Seat> Seats => Set<Seat>();
    }
}

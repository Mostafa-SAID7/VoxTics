using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;

namespace VoxTics.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieImg> MovieImgs { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- MovieCategory (Many-to-Many between Movie & Category)
            modelBuilder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.MovieId, mc.CategoryId });

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- MovieActor (Many-to-Many between Movie & Actor)
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- MovieImg (One-to-Many Movie → Images)
            modelBuilder.Entity<MovieImg>()
                .HasOne(mi => mi.Movie)
                .WithMany(m => m.Images) // ✅ match entity name
                .HasForeignKey(mi => mi.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Showtime (One-to-Many Movie → Showtimes; One-to-Many Cinema → Showtimes)
            modelBuilder.Entity<Showtime>()
                .HasOne(st => st.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(st => st.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ avoid cascade loop

            modelBuilder.Entity<Showtime>()
                .HasOne(st => st.Cinema)
                .WithMany(c => c.Showtimes)
                .HasForeignKey(st => st.CinemaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Showtime>()
                .HasOne(st => st.Hall)
                .WithMany(h => h.Showtimes)
                .HasForeignKey(st => st.HallId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Booking (One-to-Many Showtime → Bookings; One-to-Many User → Bookings)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Showtime)
                .WithMany(st => st.Bookings)
                .HasForeignKey(b => b.ShowtimeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Hall → Cinema
            modelBuilder.Entity<Hall>()
                .HasOne(h => h.Cinema)
                .WithMany(c => c.Halls)
                .HasForeignKey(h => h.CinemaId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Seat → Hall
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Seats)
                .HasForeignKey(s => s.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Global constraints
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Actor>()
                .Property(a => a.FullName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();
            // Constrain string max lengths & required where appropriate
            modelBuilder.Entity<Movie>().Property(m => m.Title).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Actor>().Property(a => a.FullName).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(200).IsRequired();

            // Map DB set name for MovieImgs (optional)
            modelBuilder.Entity<MovieImg>().ToTable("MovieImgs");
        }
    }
}

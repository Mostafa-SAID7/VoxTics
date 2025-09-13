using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VoxTics.Data
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingSeat> BookingSeats { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;
        public DbSet<Hall> Halls { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MovieActor> MovieActors { get; set; } = null!;
        public DbSet<MovieCategory> MovieCategories { get; set; } = null!;
        public DbSet<MovieImg> MovieImages { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<Showtime> Showtimes { get; set; } = null!;
        public DbSet<UserOTP> UserOTPs { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints
            ConfigureCinemaEntity(modelBuilder);
            ConfigureHallEntity(modelBuilder);
            ConfigureSeatEntity(modelBuilder);
            ConfigureMovieEntity(modelBuilder);
            ConfigureActorEntity(modelBuilder);
            ConfigureCategoryEntity(modelBuilder);
            ConfigureShowtimeEntity(modelBuilder);
            ConfigureBookingEntity(modelBuilder);
            ConfigureBookingSeatEntity(modelBuilder);
            ConfigureMovieActorEntity(modelBuilder);
            ConfigureMovieCategoryEntity(modelBuilder);
            ConfigureMovieImgEntity(modelBuilder);
        }

        private static void ConfigureCinemaEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.Halls).WithOne(e => e.Cinema).HasForeignKey(e => e.CinemaId);
            });
        }

        private static void ConfigureHallEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Cinema).WithMany(e => e.Halls).HasForeignKey(e => e.CinemaId);
                entity.HasMany(e => e.Seats).WithOne(e => e.Hall).HasForeignKey(e => e.HallId);
            });
        }

        private static void ConfigureSeatEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
                entity.HasOne(e => e.Hall).WithMany(e => e.Seats).HasForeignKey(e => e.HallId);
                entity.HasIndex(e => new { e.HallId, e.SeatNumber }).IsUnique();
            });
        }

        private static void ConfigureMovieEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Director).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Language).IsRequired().HasMaxLength(20);
                entity.HasMany(e => e.Showtimes).WithOne(e => e.Movie).HasForeignKey(e => e.MovieId);
            });
        }

        private static void ConfigureActorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            });
        }

        private static void ConfigureCategoryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }

        private static void ConfigureShowtimeEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");
                entity.HasOne(e => e.Movie).WithMany(e => e.Showtimes).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Cinema).WithMany(e => e.Showtimes).HasForeignKey(e => e.CinemaId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Hall).WithMany(e => e.Showtimes).HasForeignKey(e => e.HallId).OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureBookingEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)");
                entity.HasOne(e => e.User).WithMany(e => e.Bookings).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Showtime).WithMany(e => e.Bookings).HasForeignKey(e => e.ShowtimeId);
            });
        }

        private static void ConfigureBookingSeatEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSeat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SeatPrice).HasColumnType("decimal(8,2)");
                entity.HasOne(e => e.Booking).WithMany(e => e.BookingSeats).HasForeignKey(e => e.BookingId);
                entity.HasOne(e => e.Seat).WithMany(e => e.BookingSeats).HasForeignKey(e => e.SeatId);
                entity.HasIndex(e => new { e.BookingId, e.SeatId }).IsUnique();
            });
        }

        private static void ConfigureMovieActorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieActors).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Actor).WithMany(e => e.MovieActors).HasForeignKey(e => e.ActorId);
                entity.HasIndex(e => new { e.MovieId, e.ActorId }).IsUnique();
            });
        }

        private static void ConfigureMovieCategoryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieCategories).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Category).WithMany(e => e.MovieCategories).HasForeignKey(e => e.CategoryId);
                entity.HasIndex(e => new { e.MovieId, e.CategoryId }).IsUnique();
            });
        }

        private static void ConfigureMovieImgEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(200);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieImages).HasForeignKey(e => e.MovieId);
            });
        }
    }
}

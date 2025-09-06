// Data/MovieDbContext.cs
using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieImg> MovieImages { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships and constraints
            ConfigureUserEntity(modelBuilder);
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

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(100);
            });
        }

        private void ConfigureCinemaEntity(ModelBuilder modelBuilder)
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

        private void ConfigureHallEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Cinema).WithMany(e => e.Halls).HasForeignKey(e => e.CinemaId);
                entity.HasMany(e => e.Seats).WithOne(e => e.Hall).HasForeignKey(e => e.HallId);
            });
        }

        private void ConfigureSeatEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
                entity.HasOne(e => e.Hall).WithMany(e => e.Seats).HasForeignKey(e => e.HallId);
                entity.HasIndex(e => new { e.HallId, e.SeatNumber }).IsUnique();
            });
        }

        private void ConfigureMovieEntity(ModelBuilder modelBuilder)
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

        private void ConfigureActorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }

        private void ConfigureCategoryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }

        private void ConfigureShowtimeEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");
                entity.HasOne(e => e.Movie).WithMany(e => e.Showtimes).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Cinema).WithMany(e => e.Showtimes).HasForeignKey(e => e.CinemaId);
                entity.HasOne(e => e.Hall).WithMany(e => e.Showtimes).HasForeignKey(e => e.HallId);
            });
        }

        private void ConfigureBookingEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10,2)");
                entity.HasOne(e => e.User).WithMany(e => e.Bookings).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.Showtime).WithMany(e => e.Bookings).HasForeignKey(e => e.ShowtimeId);
            });
        }

        private void ConfigureBookingSeatEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSeat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");
                entity.HasOne(e => e.Booking).WithMany(e => e.BookingSeats).HasForeignKey(e => e.BookingId);
                entity.HasOne(e => e.Seat).WithMany(e => e.BookingSeats).HasForeignKey(e => e.SeatId);
                entity.HasIndex(e => new { e.BookingId, e.SeatId }).IsUnique();
            });
        }

        private void ConfigureMovieActorEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieActors).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Actor).WithMany(e => e.MovieActors).HasForeignKey(e => e.ActorId);
                entity.HasIndex(e => new { e.MovieId, e.ActorId }).IsUnique();
            });
        }

        private void ConfigureMovieCategoryEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieCategories).HasForeignKey(e => e.MovieId);
                entity.HasOne(e => e.Category).WithMany(e => e.MovieCategories).HasForeignKey(e => e.CategoryId);
                entity.HasIndex(e => new { e.MovieId, e.CategoryId }).IsUnique();
            });
        }

        private void ConfigureMovieImgEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(200);
                entity.HasOne(e => e.Movie).WithMany(e => e.MovieImages).HasForeignKey(e => e.MovieId);
            });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Description = "Action movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 2, Name = "Comedy", Description = "Comedy movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 3, Name = "Drama", Description = "Drama movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 4, Name = "Horror", Description = "Horror movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 5, Name = "Romance", Description = "Romance movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 6, Name = "Sci-Fi", Description = "Science Fiction movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 7, Name = "Thriller", Description = "Thriller movies", IsActive = true, CreatedDate = DateTime.Now },
                new Category { Id = 8, Name = "Animation", Description = "Animated movies", IsActive = true, CreatedDate = DateTime.Now }
            );

            // Seed User Roles
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@cinema.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEH3QhLhFhBpz9Kpx8qHiuZs1kJ2sNFKJCyKGXUwNdU9u6Vp8IJ1aGk3K3wIZl4M5QQ==", // Password123!
                    Role = UserRole.Administrator,
                    IsActive = true,
                    IsEmailConfirmed = true,
                    CreatedDate = DateTime.Now
                }
            );

            // Seed Cinemas
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema
                {
                    Id = 1,
                    Name = "Grand Cinema",
                    Address = "123 Main Street",
                    City = "Downtown",
                    Phone = "555-0123",
                    Email = "info@grandcinema.com",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Cinema
                {
                    Id = 2,
                    Name = "City Center Cinema",
                    Address = "456 Central Avenue",
                    City = "City Center",
                    Phone = "555-0456",
                    Email = "info@citycentercinema.com",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );

            // Seed Actors
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Robert Downey Jr.", Nationality = "American", IsActive = true, CreatedDate = DateTime.Now },
                new Actor { Id = 2, Name = "Scarlett Johansson", Nationality = "American", IsActive = true, CreatedDate = DateTime.Now },
                new Actor { Id = 3, Name = "Chris Evans", Nationality = "American", IsActive = true, CreatedDate = DateTime.Now },
                new Actor { Id = 4, Name = "Jennifer Lawrence", Nationality = "American", IsActive = true, CreatedDate = DateTime.Now },
                new Actor { Id = 5, Name = "Leonardo DiCaprio", Nationality = "American", IsActive = true, CreatedDate = DateTime.Now }
            );
        }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
        }
    }
}
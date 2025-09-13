using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;

namespace VoxTics.Data
{
    public class MovieDbContext : IdentityDbContext<ApplicationUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Always call the base first for Identity tables
            base.OnModelCreating(modelBuilder);

            // ===== Booking & User =====
            // Booking.User -> AspNetUsers (ApplicationUser)
            modelBuilder.Entity<Booking>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.TotalAmount).HasColumnType("decimal(10,2)");

                b.HasOne(x => x.User)
                 .WithMany(u => u.Bookings)
                 .HasForeignKey(x => x.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict); // don't cascade delete users -> bookings

                // Booking -> BookingSeats is configured below in BookingSeat section
            });

            // ===== Cinema =====
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // When a Cinema is deleted, delete its Halls (cascade).
                // This allows a single cascade path to Showtimes: Cinema -> Halls -> Showtimes
                entity.HasMany(c => c.Halls)
                      .WithOne(h => h.Cinema)
                      .HasForeignKey(h => h.CinemaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ===== Hall =====
            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                // When a Hall is deleted, delete its Seats (cascade).
                entity.HasMany(h => h.Seats)
                      .WithOne(s => s.Hall)
                      .HasForeignKey(s => s.HallId)
                      .OnDelete(DeleteBehavior.Cascade);

                // When a Hall is deleted, delete its Showtimes (cascade).
                // This creates the single cascade path to Showtimes: Cinema -> Halls -> Showtimes
                entity.HasMany(h => h.Showtimes)
                      .WithOne(s => s.Hall)
                      .HasForeignKey(s => s.HallId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ===== Seat =====
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
                entity.HasIndex(e => new { e.HallId, e.SeatNumber }).IsUnique();

                // If you want BookingSeats navigation on Seat, configure inverse:
                // entity.HasMany(s => s.BookingSeats).WithOne(bs => bs.Seat).HasForeignKey(bs => bs.SeatId).OnDelete(DeleteBehavior.Restrict);
            });

            // ===== Movie =====
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);

                // Make Movie -> Showtimes explicit to avoid accidental cascades.
                entity.HasMany(m => m.Showtimes)
                      .WithOne(s => s.Movie)
                      .HasForeignKey(s => s.MovieId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ===== Actor =====
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            });

            // ===== Category =====
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            // ===== Showtime =====
            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnType("decimal(8,2)");

                // Avoid direct cascade from Cinema to Showtimes to prevent multiple cascade paths.
                entity.HasOne(s => s.Cinema)
                      .WithMany(c => c.Showtimes)
                      .HasForeignKey(s => s.CinemaId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Hall -> Showtimes cascade is configured on Hall entity (see above).
                // Movie -> Showtimes is configured on Movie entity (see above).
            });

            // ===== BookingSeat =====
            modelBuilder.Entity<BookingSeat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SeatPrice).HasColumnType("decimal(8,2)");

                entity.HasOne(bs => bs.Booking)
                      .WithMany(b => b.BookingSeats)
                      .HasForeignKey(bs => bs.BookingId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade); // delete booking -> delete its booking seats

                entity.HasOne(bs => bs.Seat)
                      .WithMany(s => s.BookingSeats)
                      .HasForeignKey(bs => bs.SeatId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict); // prevent cascading via Seat

                entity.HasIndex(e => new { e.BookingId, e.SeatId }).IsUnique();
            });

            // ===== MovieActor (join) =====
            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.MovieId, e.ActorId }).IsUnique();

                entity.HasOne(ma => ma.Movie)
                      .WithMany(m => m.MovieActors)
                      .HasForeignKey(ma => ma.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ma => ma.Actor)
                      .WithMany(a => a.MovieActors)
                      .HasForeignKey(ma => ma.ActorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ===== MovieCategory (join) =====
            modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.MovieId, e.CategoryId }).IsUnique();

                entity.HasOne(mc => mc.Movie)
                      .WithMany(m => m.MovieCategories)
                      .HasForeignKey(mc => mc.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Category)
                      .WithMany(c => c.MovieCategories)
                      .HasForeignKey(mc => mc.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ===== MovieImg =====
            modelBuilder.Entity<MovieImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(200);

                entity.HasOne(mi => mi.Movie)
                      .WithMany(m => m.MovieImages)
                      .HasForeignKey(mi => mi.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ===== Optional: UserOTP =====
            modelBuilder.Entity<UserOTP>(entity =>
            {
                entity.HasKey(e => e.Id);
                // configure fields as needed (expiration, code, user FK, etc.)
            });
        }
    }
}

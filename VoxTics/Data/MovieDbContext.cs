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
            base.OnModelCreating(modelBuilder);

            ConfigureBooking(modelBuilder);
            ConfigureCinema(modelBuilder);
            ConfigureHall(modelBuilder);
            ConfigureSeat(modelBuilder);
            ConfigureMovie(modelBuilder);
            ConfigureActor(modelBuilder);
            ConfigureCategory(modelBuilder);
            ConfigureShowtime(modelBuilder);
            ConfigureBookingSeat(modelBuilder);
            ConfigureMovieActor(modelBuilder);
            ConfigureMovieCategory(modelBuilder);
            ConfigureMovieImg(modelBuilder);
            ConfigureUserOTP(modelBuilder);
        }

        private void ConfigureBooking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.TotalAmount).HasColumnType("decimal(10,2)");

                // Booking → User
                b.HasOne(x => x.User)
                 .WithMany(u => u.Bookings)
                 .HasForeignKey(x => x.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                // Booking → Cinema
                b.HasOne(x => x.Cinema)
                 .WithMany(c => c.Bookings)
                 .HasForeignKey(x => x.CinemaId)
                 .OnDelete(DeleteBehavior.Restrict);

                // Booking → Movie
                b.HasOne(x => x.Movie)
                 .WithMany(m => m.Bookings)
                 .HasForeignKey(x => x.MovieId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureCinema(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // Cinema → Halls (cascade delete allowed)
                c.HasMany(c => c.Halls)
                 .WithOne(h => h.Cinema)
                 .HasForeignKey(h => h.CinemaId)
                 .OnDelete(DeleteBehavior.Cascade);

                // Cinema → Showtimes (restrict)
                c.HasMany(c => c.Showtimes)
                 .WithOne(s => s.Cinema)
                 .HasForeignKey(s => s.CinemaId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureHall(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>(h =>
            {
                h.HasKey(e => e.Id);
                h.Property(e => e.Name).IsRequired().HasMaxLength(50);

                h.HasMany(h => h.Seats)
                 .WithOne(s => s.Hall)
                 .HasForeignKey(s => s.HallId)
                 .OnDelete(DeleteBehavior.Cascade);

                h.HasMany(h => h.Showtimes)
                 .WithOne(s => s.Hall)
                 .HasForeignKey(s => s.HallId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureSeat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seat>(s =>
            {
                s.HasKey(e => e.Id);
                s.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
                s.HasIndex(e => new { e.HallId, e.SeatNumber }).IsUnique();
            });
        }

        private void ConfigureMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(m =>
            {
                m.HasKey(e => e.Id);
                m.Property(e => e.Title).IsRequired().HasMaxLength(100);

                m.HasMany(m => m.Showtimes)
                 .WithOne(s => s.Movie)
                 .HasForeignKey(s => s.MovieId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureActor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(a =>
            {
                a.HasKey(e => e.Id);
                a.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            });
        }

        private void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Name).IsRequired().HasMaxLength(50);
                c.HasIndex(e => e.Name).IsUnique();
            });
        }

        private void ConfigureShowtime(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>(s =>
            {
                s.HasKey(e => e.Id);
                s.Property(e => e.Price).HasColumnType("decimal(8,2)");
            });
        }

        private void ConfigureBookingSeat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSeat>(bs =>
            {
                bs.HasKey(e => e.Id);
                bs.Property(e => e.SeatPrice).HasColumnType("decimal(8,2)");

                bs.HasOne(b => b.Booking)
                  .WithMany(bk => bk.BookingSeats)
                  .HasForeignKey(b => b.BookingId)
                  .OnDelete(DeleteBehavior.Cascade);

                bs.HasOne(b => b.Seat)
                  .WithMany(s => s.BookingSeats)
                  .HasForeignKey(b => b.SeatId)
                  .OnDelete(DeleteBehavior.Restrict);

                bs.HasIndex(e => new { e.BookingId, e.SeatId }).IsUnique();
            });
        }

        private void ConfigureMovieActor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>(ma =>
            {
                ma.HasKey(e => e.Id);
                ma.HasIndex(e => new { e.MovieId, e.ActorId }).IsUnique();

                ma.HasOne(ma => ma.Movie)
                  .WithMany(m => m.MovieActors)
                  .HasForeignKey(ma => ma.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);

                ma.HasOne(ma => ma.Actor)
                  .WithMany(a => a.MovieActors)
                  .HasForeignKey(ma => ma.ActorId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureMovieCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>(mc =>
            {
                mc.HasKey(e => e.Id);
                mc.HasIndex(e => new { e.MovieId, e.CategoryId }).IsUnique();

                mc.HasOne(mc => mc.Movie)
                  .WithMany(m => m.MovieCategories)
                  .HasForeignKey(mc => mc.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);

                mc.HasOne(mc => mc.Category)
                  .WithMany(c => c.MovieCategories)
                  .HasForeignKey(mc => mc.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureMovieImg(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieImg>(mi =>
            {
                mi.HasKey(e => e.Id);
                mi.Property(e => e.ImageUrl).IsRequired().HasMaxLength(200);

                mi.HasOne(mi => mi.Movie)
                  .WithMany(m => m.MovieImages)
                  .HasForeignKey(mi => mi.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureUserOTP(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOTP>(u =>
            {
                u.HasKey(e => e.Id);
                // configure expiration, code, and user FK as needed
            });
        }
    }
}

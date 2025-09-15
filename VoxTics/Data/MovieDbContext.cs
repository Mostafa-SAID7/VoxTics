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
        public DbSet<UserMovieWatchlist> UserMovieWatchlists { get; set; } = null!; // legacy
        public DbSet<Watchlist> Watchlists { get; set; } = null!;
        public DbSet<WatchlistItem> WatchlistItems { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // core domain
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

            // identity / misc
            ConfigureUserOTP(modelBuilder);

            // legacy and new user-related features
            ConfigureLegacyUserMovieWatchlist(modelBuilder);
            ConfigureWatchlist(modelBuilder);
            ConfigureWatchlistItem(modelBuilder);
            ConfigureCart(modelBuilder);
            ConfigureCartItem(modelBuilder);
            ConfigurePayment(modelBuilder);
            ConfigureNotification(modelBuilder);
        }

        #region Core entity configurations

        private static void ConfigureBooking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.TotalAmount).HasColumnType("decimal(10,2)");

                // Booking -> User
                b.HasOne(x => x.User)
                 .WithMany(u => u.Bookings)
                 .HasForeignKey(x => x.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

                // Booking -> Cinema
                b.HasOne(x => x.Cinema)
                 .WithMany(c => c.Bookings)
                 .HasForeignKey(x => x.CinemaId)
                 .OnDelete(DeleteBehavior.Restrict);

                // Booking -> Movie
                b.HasOne(x => x.Movie)
                 .WithMany(m => m.Bookings)
                 .HasForeignKey(x => x.MovieId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureCinema(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Name).IsRequired().HasMaxLength(100);

                c.HasMany(e => e.Halls)
                 .WithOne(h => h.Cinema)
                 .HasForeignKey(h => h.CinemaId)
                 .OnDelete(DeleteBehavior.Cascade);

                c.HasMany(e => e.Showtimes)
                 .WithOne(s => s.Cinema)
                 .HasForeignKey(s => s.CinemaId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void ConfigureHall(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>(h =>
            {
                h.HasKey(e => e.Id);
                h.Property(e => e.Name).IsRequired().HasMaxLength(50);

                h.HasMany(e => e.Seats)
                 .WithOne(s => s.Hall)
                 .HasForeignKey(s => s.HallId)
                 .OnDelete(DeleteBehavior.Cascade);

                h.HasMany(e => e.Showtimes)
                 .WithOne(s => s.Hall)
                 .HasForeignKey(s => s.HallId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureSeat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seat>(s =>
            {
                s.HasKey(e => e.Id);
                s.Property(e => e.SeatNumber).IsRequired().HasMaxLength(10);
                s.HasIndex(e => new { e.HallId, e.SeatNumber }).IsUnique();
            });
        }

        private static void ConfigureMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(m =>
            {
                m.HasKey(e => e.Id);
                m.Property(e => e.Title).IsRequired().HasMaxLength(200);

                m.HasMany(e => e.Showtimes)
                 .WithOne(s => s.Movie)
                 .HasForeignKey(s => s.MovieId)
                 .OnDelete(DeleteBehavior.Restrict);

                // optional: ensure collections exist on Movie entity (WatchlistItems, CartItems, etc.)
                m.HasMany(e => e.MovieActors).WithOne(ma => ma.Movie).HasForeignKey(ma => ma.MovieId);
                m.HasMany(e => e.MovieCategories).WithOne(mc => mc.Movie).HasForeignKey(mc => mc.MovieId);
                m.HasMany(e => e.MovieImages).WithOne(mi => mi.Movie).HasForeignKey(mi => mi.MovieId);
            });
        }

        private static void ConfigureActor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(a =>
            {
                a.HasKey(e => e.Id);
                a.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            });
        }

        private static void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(e => e.Id);
                c.Property(e => e.Name).IsRequired().HasMaxLength(50);
                c.HasIndex(e => e.Name).IsUnique();
            });
        }

        private static void ConfigureShowtime(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>(s =>
            {
                s.HasKey(e => e.Id);
                s.Property(e => e.Price).HasColumnType("decimal(8,2)");
            });
        }

        private static void ConfigureBookingSeat(ModelBuilder modelBuilder)
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

        private static void ConfigureMovieActor(ModelBuilder modelBuilder)
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

        private static void ConfigureMovieCategory(ModelBuilder modelBuilder)
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

        private static void ConfigureMovieImg(ModelBuilder modelBuilder)
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

        #endregion

        #region Identity-related & new entities

        private static void ConfigureUserOTP(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOTP>(u =>
            {
                u.HasKey(x => x.Id);

                u.HasOne(x => x.ApplicationUser)
                 .WithMany(a => a.UserOTPs)
                 .HasForeignKey(x => x.ApplicationUserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        /// <summary>
        /// Legacy simple join table (userId + movieId) kept for compatibility.
        /// If you drop legacy usage remove this entity & DbSet.
        /// </summary>
        private static void ConfigureLegacyUserMovieWatchlist(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMovieWatchlist>(umw =>
            {
                umw.HasKey(x => new { x.UserId, x.MovieId });

                umw.HasOne(x => x.User)
                   .WithMany(u => u.UserMovieWatchlists)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

                umw.HasOne(x => x.Movie)
                   .WithMany(m => m.UserMovieWatchlists)
                   .HasForeignKey(x => x.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureWatchlist(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watchlist>(w =>
            {
                w.HasKey(x => x.Id);

                w.Property(x => x.Name).HasMaxLength(100).IsRequired();

                w.HasOne(x => x.User)
                 .WithMany(u => u.Watchlists)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureWatchlistItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchlistItem>(wi =>
            {
                wi.HasKey(x => new { x.WatchlistId, x.MovieId });

                wi.HasOne(x => x.Watchlist)
                  .WithMany(w => w.WatchlistItems)
                  .HasForeignKey(x => x.WatchlistId)
                  .OnDelete(DeleteBehavior.Cascade);

                wi.HasOne(x => x.Movie)
                  .WithMany(m => m.WatchlistItems)
                  .HasForeignKey(x => x.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureCart(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasOne(x => x.User)
                 .WithMany(u => u.Carts)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

                // Cart does NOT have direct Movie nav - CartItem links movies to carts.
            });
        }

        private static void ConfigureCartItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(ci =>
            {
                ci.HasKey(x => new { x.CartId, x.MovieId });

                ci.HasOne(x => x.Cart)
                  .WithMany(c => c.CartItems)
                  .HasForeignKey(x => x.CartId)
                  .OnDelete(DeleteBehavior.Cascade);

                ci.HasOne(x => x.Movie)
                  .WithMany(m => m.CartItems)
                  .HasForeignKey(x => x.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);

                ci.Property(x => x.Price).HasColumnType("decimal(10,2)");
                ci.Property(x => x.Quantity).HasDefaultValue(1);
            });
        }

        private static void ConfigurePayment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(p =>
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Amount).HasColumnType("decimal(10,2)");

                p.HasOne(x => x.User)
                 .WithMany(u => u.Payments)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

                // optional link to booking
                p.HasOne<Booking>()
                 .WithMany()
                 .HasForeignKey(x => x.BookingId)
                 .OnDelete(DeleteBehavior.SetNull);
            });
        }

        private static void ConfigureNotification(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(n =>
            {
                n.HasKey(x => x.Id);
                n.Property(x => x.Title).HasMaxLength(200);
                n.Property(x => x.Message).HasMaxLength(2000);

                n.HasOne(x => x.User)
                 .WithMany(u => u.Notifications)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
    {
        public void Configure(EntityTypeBuilder<Showtime> builder)
        {
            builder.ToTable("Showtimes");

            builder.Property(s => s.MovieId).IsRequired();
            builder.Property(s => s.HallId).IsRequired();
            builder.Property(s => s.CinemaId).IsRequired();
            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.Price).IsRequired().HasColumnType("decimal(8,2)");
            builder.Property(s => s.Status).IsRequired().HasDefaultValue(ShowtimeStatus.Scheduled);
            builder.Property(s => s.Is3D).HasDefaultValue(false);
            builder.Property(s => s.Language).HasMaxLength(50).HasDefaultValue("EN");
            builder.Property(s => s.ScreenType).HasMaxLength(50).HasDefaultValue("Standard");
            builder.Property(s => s.AvailableSeats).IsRequired();
            builder.Property(s => s.RowVersion).IsRowVersion();
            builder.Property(s => s.IsCancelled).HasDefaultValue(false);

            // Relationships
            builder.HasOne(s => s.Movie)
                   .WithMany(m => m.Showtimes)
                   .HasForeignKey(s => s.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Hall)
                   .WithMany(h => h.Showtimes)
                   .HasForeignKey(s => s.HallId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths

            builder.HasOne(s => s.Cinema)
                   .WithMany(c => c.Showtimes)
                   .HasForeignKey(s => s.CinemaId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths

            builder.HasMany(s => s.Bookings)
                   .WithOne(b => b.Showtime)
                   .HasForeignKey(b => b.ShowtimeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.CartItems)
                   .WithOne(c => c.Showtime)
                   .HasForeignKey(c => c.ShowtimeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(s => s.EndTime);
        }
    }
}

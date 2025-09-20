using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.DiscountAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(b => b.FinalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.NumberOfTickets).IsRequired();
            builder.Property(b => b.Status).HasDefaultValue(BookingStatus.Pending).IsRequired();
            builder.Property(b => b.BookingDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(b => b.IsCheckedIn).HasDefaultValue(false);

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // Safe

            builder.HasOne(b => b.Showtime)
                   .WithMany(s => s.Bookings)
                   .HasForeignKey(b => b.ShowtimeId)
                   .OnDelete(DeleteBehavior.Restrict); // Safe

            builder.HasMany(b => b.BookingSeats)
                   .WithOne(bs => bs.Booking)
                   .HasForeignKey(bs => bs.BookingId)
                   .OnDelete(DeleteBehavior.Cascade); // Only cascade from Booking → BookingSeats

            builder.HasMany(b => b.Payments)
                   .WithOne(p => p.Booking)
                   .HasForeignKey(p => p.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Ignore computed properties
            builder.Ignore(b => b.CanBeCancelled);
            builder.Ignore(b => b.BookingReference);
        }
    }
}

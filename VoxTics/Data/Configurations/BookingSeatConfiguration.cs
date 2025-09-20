using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class BookingSeatConfiguration : IEntityTypeConfiguration<BookingSeat>
    {
        public void Configure(EntityTypeBuilder<BookingSeat> builder)
        {
            builder.HasKey(bs => bs.Id);

            builder.Property(bs => bs.SeatPrice).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(bs => bs.Booking)
                   .WithMany(b => b.BookingSeats)
                   .HasForeignKey(bs => bs.BookingId)
                   .OnDelete(DeleteBehavior.Cascade); // Safe, single cascade path

            builder.HasOne(bs => bs.Seat)
                   .WithMany(s => s.BookingSeats)
                   .HasForeignKey(bs => bs.SeatId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths

            builder.HasIndex(bs => new { bs.BookingId, bs.SeatId }).IsUnique();

            builder.Ignore(bs => bs.SeatLabel);
        }
    }
}

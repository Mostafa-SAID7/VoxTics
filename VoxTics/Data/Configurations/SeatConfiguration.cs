using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");

            builder.Property(s => s.HallId).IsRequired();
            builder.Property(s => s.Row).IsRequired().HasMaxLength(1);
            builder.Property(s => s.NumberInRow).IsRequired();
            builder.Property(s => s.Type).IsRequired().HasDefaultValue(SeatType.VIP);
            builder.Property(s => s.IsActive).HasDefaultValue(true);
            builder.Property(s => s.IsAvailable).HasDefaultValue(true);
            builder.Property(s => s.SeatNumber).IsRequired().HasMaxLength(10);

            // Relationships
            builder.HasOne(s => s.Hall)
                   .WithMany(h => h.Seats)
                   .HasForeignKey(s => s.HallId)
                   .OnDelete(DeleteBehavior.Cascade); // Safe

            builder.HasMany(s => s.BookingSeats)
                   .WithOne(bs => bs.Seat)
                   .HasForeignKey(bs => bs.SeatId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent multiple cascade paths
        }
    }
}

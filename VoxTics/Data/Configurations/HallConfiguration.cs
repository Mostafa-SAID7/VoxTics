using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            // Table name
            builder.ToTable("Halls");

            // Properties
            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(h => h.TotalSeats)
                   .IsRequired();

            builder.Property(h => h.Description)
                   .HasMaxLength(500);

            builder.Property(h => h.IsActive)
                   .HasDefaultValue(true);

            builder.Property(h => h.CinemaId)
                   .IsRequired();

            // Relationships
            builder.HasOne(h => h.Cinema)
                   .WithMany(c => c.Halls)
                   .HasForeignKey(h => h.CinemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.Seats)
                   .WithOne(s => s.Hall)
                   .HasForeignKey(s => s.HallId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.Showtimes)
                   .WithOne(s => s.Hall)
                   .HasForeignKey(s => s.HallId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Ignore computed / not-mapped properties
            builder.Ignore(h => h.SeatCount);
        }
    }
}

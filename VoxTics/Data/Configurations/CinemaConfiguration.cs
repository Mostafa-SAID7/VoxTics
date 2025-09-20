using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            // Table name
            builder.ToTable("Cinemas");

            // Primary key is inherited from BaseEntity, so no need to configure

            // Properties
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20);

            builder.Property(c => c.Address)
                   .HasMaxLength(200);

            builder.Property(c => c.City)
                   .HasMaxLength(100);

            builder.Property(c => c.State)
                   .HasMaxLength(100);

            builder.Property(c => c.Country)
                   .HasMaxLength(100);

            builder.Property(c => c.PostalCode)
                   .HasMaxLength(20);

            builder.Property(c => c.Website)
                   .HasMaxLength(200);

            builder.Property(c => c.ImageUrl)
                   .HasMaxLength(200);

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            // Relationships
            builder.HasMany(c => c.Halls)
                   .WithOne(h => h.Cinema)
                   .HasForeignKey(h => h.CinemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Showtimes)
                   .WithOne(s => s.Cinema)
                   .HasForeignKey(s => s.CinemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.SocialMediaLinks)
                   .WithOne(s => s.Cinema)
                   .HasForeignKey(s => s.CinemaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Ignore computed / not-mapped properties
            builder.Ignore(c => c.TotalSeats);
            builder.Ignore(c => c.HallCount);
            builder.Ignore(c => c.ShowtimeCount);
            builder.Ignore(c => c.DisplayImage);
        }
    }
}

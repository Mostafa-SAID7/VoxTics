using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Table name
            builder.ToTable("Movies");

            // Properties
            builder.Property(m => m.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(m => m.Director)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.ReleaseDate)
                   .IsRequired();

            builder.Property(m => m.EndDate);

            builder.Property(m => m.Duration)
                   .IsRequired();

            builder.Property(m => m.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(m => m.Rating);

            builder.Property(m => m.Language)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue("EN");

            builder.Property(m => m.Country)
                   .HasMaxLength(50);

            builder.Property(m => m.MainImage);

            builder.Property(m => m.TrailerUrl);

            builder.Property(m => m.IsFeatured)
                   .HasDefaultValue(false);

            builder.Property(m => m.Status)
                   .IsRequired();

            builder.Property(m => m.Slug)
                   .IsRequired()
                   .HasMaxLength(150);

            // Relationships
            builder.HasMany(m => m.MovieActors)
                   .WithOne(ma => ma.Movie)
                   .HasForeignKey(ma => ma.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.MovieImages)
                   .WithOne(mi => mi.Movie)
                   .HasForeignKey(mi => mi.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Showtimes)
                   .WithOne(s => s.Movie)
                   .HasForeignKey(s => s.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(m => m.WatchlistItems)
                   .WithOne(w => w.Movie)
                   .HasForeignKey(w => w.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.CartItems)
                   .WithOne(c => c.Movie)
                   .HasForeignKey(c => c.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);


         
        }
    }
}

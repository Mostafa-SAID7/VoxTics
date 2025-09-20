using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class MovieImgConfiguration : IEntityTypeConfiguration<MovieImg>
    {
        public void Configure(EntityTypeBuilder<MovieImg> builder)
        {
            // Table name
            builder.ToTable("MovieImages");

            // Properties
            builder.Property(mi => mi.MovieId)
                   .IsRequired();

            builder.Property(mi => mi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(mi => mi.AltText)
                   .HasMaxLength(200);

            builder.Property(mi => mi.IsMain)
                   .HasDefaultValue(false);

            // Relationships
            builder.HasOne(mi => mi.Movie)
                   .WithMany(m => m.MovieImages)
                   .HasForeignKey(mi => mi.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            // Table name
            builder.ToTable("MovieActors");

            // Composite primary key
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });

            // Relationships
            builder.HasOne(ma => ma.Movie)
                   .WithMany(m => m.MovieActors)
                   .HasForeignKey(ma => ma.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ma => ma.Actor)
                   .WithMany(a => a.MovieActors)
                   .HasForeignKey(ma => ma.ActorId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Optional: Role/Character name if you have it
         

            // Other properties if needed
        }
    }
}

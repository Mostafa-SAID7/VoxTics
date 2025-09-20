using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Bio).HasMaxLength(500);
            builder.Property(a => a.ImageUrl).HasMaxLength(250);
            builder.Property(a => a.Nationality).HasMaxLength(100);
        }
    }
}

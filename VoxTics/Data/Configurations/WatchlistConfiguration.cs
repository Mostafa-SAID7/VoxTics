using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
    {
        public void Configure(EntityTypeBuilder<Watchlist> builder)
        {
            // Table name
            builder.ToTable("Watchlists");

            // Properties
            builder.Property(w => w.UserId)
                   .IsRequired();

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasDefaultValue("Default");

            // Relationships
            builder.HasOne(w => w.User)
                   .WithMany(u => u.Watchlists) // Ensure ApplicationUser has a collection of Watchlists
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.WatchlistItems)
                   .WithOne(wi => wi.Watchlist)
                   .HasForeignKey(wi => wi.WatchlistId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class WatchlistItemConfiguration : IEntityTypeConfiguration<WatchlistItem>
    {
        public void Configure(EntityTypeBuilder<WatchlistItem> builder)
        {
            // Table name
            builder.ToTable("WatchlistItems");

            // Properties
            builder.Property(wi => wi.WatchlistId)
                   .IsRequired();

            builder.Property(wi => wi.MovieId)
                   .IsRequired();

            builder.Property(wi => wi.AddedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(wi => wi.Watchlist)
                   .WithMany(w => w.WatchlistItems)
                   .HasForeignKey(wi => wi.WatchlistId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wi => wi.Movie)
                   .WithMany(m => m.WatchlistItems) // Ensure Movie has WatchlistItems collection
                   .HasForeignKey(wi => wi.MovieId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Optional: unique constraint to prevent duplicates in a watchlist
            builder.HasIndex(wi => new { wi.WatchlistId, wi.MovieId })
                   .IsUnique();
        }
    }
}

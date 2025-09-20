using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);

            // Cart -> CartItems
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Movie -> CartItems
            builder.HasOne(ci => ci.Movie)
                   .WithMany(m => m.CartItems)
                   .HasForeignKey(ci => ci.MovieId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Showtime -> CartItems
            builder.HasOne(ci => ci.Showtime)
                   .WithMany(s => s.CartItems)
                   .HasForeignKey(ci => ci.ShowtimeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ci => ci.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);
        }
    }
}

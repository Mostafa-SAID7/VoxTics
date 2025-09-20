using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Table name
            builder.ToTable("Payments");

            // Properties
            builder.Property(p => p.BookingId)
                   .IsRequired();

            builder.Property(p => p.UserId)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Method)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasDefaultValue(PaymentStatus.Pending);

            builder.Property(p => p.TransactionId)
                   .HasMaxLength(200);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.PaidAt);

            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(p => p.Notes)
                   .HasMaxLength(1000);

            // Relationships
            builder.HasOne(p => p.Booking)
                   .WithMany(b => b.Payments) // Ensure Booking entity has Payments collection
                   .HasForeignKey(p => p.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                   .WithMany(u => u.Payments) // Ensure ApplicationUser entity has Payments collection
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Coupon)
                   .WithMany(c => c.Payments) // Ensure Coupon entity has Payments collection
                   .HasForeignKey(p => p.CouponId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

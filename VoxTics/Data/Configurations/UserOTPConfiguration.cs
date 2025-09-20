using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class UserOTPConfiguration : IEntityTypeConfiguration<UserOTP>
    {
        public void Configure(EntityTypeBuilder<UserOTP> builder)
        {
            // Table name
            builder.ToTable("UserOTPs");

            // Primary key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.ApplicationUserId)
                   .IsRequired();

            builder.Property(u => u.OTPNumber)
                   .IsRequired();

            builder.Property(u => u.IsUsed)
                   .HasDefaultValue(false);

            builder.Property(u => u.ValidTo)
                   .IsRequired();

            builder.Property(u => u.OTPType)
                   .IsRequired();

            // Relationships
            builder.HasOne(u => u.ApplicationUser)
                   .WithMany(a => a.UserOTPs) // Ensure ApplicationUser has a collection of UserOTPs
                   .HasForeignKey(u => u.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

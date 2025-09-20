using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoxTics.Models.Entities;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Table name
            builder.ToTable("Notifications");

            // Properties
            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(n => n.Title)
                   .HasMaxLength(200);

            builder.Property(n => n.Type)
                   .IsRequired();

            builder.Property(n => n.UserId)
                   .IsRequired();

            builder.Property(n => n.IsRead)
                   .HasDefaultValue(false);

            builder.Property(n => n.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notifications) // Ensure ApplicationUser has Notifications collection
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

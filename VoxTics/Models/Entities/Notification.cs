using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Enums.Notifications;

namespace VoxTics.Models.Entities
{
    public class Notification : BaseEntity
    {
        [Required, StringLength(1000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public string UserId { get; set; } = default!;

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;

        [StringLength(200)]
        public string? Title { get; set; }

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

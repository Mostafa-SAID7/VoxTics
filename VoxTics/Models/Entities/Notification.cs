using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Enums.Notifications;

namespace VoxTics.Models.Entities
{
    public class Notification : BaseEntity
    {
        // -------------------------
        // Required fields
        // -------------------------
        [Required, StringLength(1000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public NotificationType Type { get; set; }

        // -------------------------
        // Foreign key
        // -------------------------
        public int? UserId { get; set; }

        // -------------------------
        // Navigation property
        // -------------------------
        public virtual ApplicationUser? User { get; set; }
    }
}

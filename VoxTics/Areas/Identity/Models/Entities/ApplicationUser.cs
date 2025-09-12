using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Identity.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Basic info
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Url, StringLength(200)]
        public string? AvatarUrl { get; set; }

        // Address
        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(200)]
        public string? Street { get; set; }

        [StringLength(20)]
        public string? ZipCode { get; set; }

        // Account info
        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;
        public bool IsBanned { get; set; } = false;

        [StringLength(250)]
        public string? BanReason { get; set; }

        // Activity tracking
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Preferences and settings
        [StringLength(2000)]
        public string? PreferencesJson { get; set; }
        public DateTime? LastPasswordResetRequest { get; set; }

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}

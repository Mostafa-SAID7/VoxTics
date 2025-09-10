using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Enums;

namespace VoxTics.Areas.Identity.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Basic info
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        public string? AvatarUrl { get; set; }

        // Address
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }

        // Account info
        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;
        public bool IsBanned { get; set; } = false;

        [StringLength(250)]
        public string? BanReason { get; set; }

        // Activity
        public DateTime? LastLoginDate { get; set; }

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}

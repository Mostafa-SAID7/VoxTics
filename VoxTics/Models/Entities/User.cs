using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? AvatarUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;
        public bool IsBanned { get; set; } = false;

        [StringLength(250)]
        public string? BanReason { get; set; }

        // Email verification
        public bool IsEmailConfirmed { get; set; } = false;
        [StringLength(100)]
        public string? EmailConfirmationToken { get; set; }

        // Password reset
        [StringLength(100)]
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetExpires { get; set; }

        // Activity
        public DateTime? LastLoginDate { get; set; }

        // Preferences (stored as JSON)
        public string? PreferencesJson { get; set; }

        // Auditing (if not in BaseEntity)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();

        // Computed property
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}

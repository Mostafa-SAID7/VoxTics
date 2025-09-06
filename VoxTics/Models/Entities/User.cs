using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;

        public bool IsEmailConfirmed { get; set; } = false;

        [StringLength(100)]
        public string? EmailConfirmationToken { get; set; }

        [StringLength(100)]
        public string? PasswordResetToken { get; set; }

        public DateTime? PasswordResetExpires { get; set; }

        public DateTime? LastLoginDate { get; set; }

        // Navigation properties
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        // Computed property
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        // ✅ Optional: Social media links for user profiles
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}

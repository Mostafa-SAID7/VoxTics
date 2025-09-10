using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [Display(Name = "Profile Image")]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime RegistrationDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Display properties
        public string FullName => $"{FirstName} {LastName}";
        public string CreatedDateFormatted => CreatedDate.ToString("MMM dd, yyyy");
        public string LastLoginFormatted => LastLoginDate?.ToString("MMM dd, yyyy hh:mm tt") ?? "Never";
        public int BookingCount { get; set; }
        public bool HasImage => !string.IsNullOrEmpty(ImageUrl);
        public string DefaultImage => "/images/default-user.jpg";
        public string DisplayImage => HasImage ? ImageUrl! : DefaultImage;

        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-danger";
        public string StatusText => IsActive ? "Active" : "Inactive";

        // Role options
        public List<SelectListItem> RoleOptions { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "User", Text = "User" },
            new SelectListItem { Value = "Admin", Text = "Admin" }
        };
       


        

       

        [Display(Name = "Profile Image")]
        public IFormFile? ProfileImageFile { get; set; }

        public string? CurrentProfileImage { get; set; }


       

        [Display(Name = "Password")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string? ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int TotalBookings { get; set; }
        public decimal TotalSpent { get; set; }
       
    }
}

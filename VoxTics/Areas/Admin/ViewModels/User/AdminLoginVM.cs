using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.User
{
    public class AdminLoginVM
    {
        [Required(ErrorMessage = "Username or Email is required")]
        [Display(Name = "Username or Email")]
        [StringLength(100, ErrorMessage = "Username or Email cannot exceed 100 characters")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = false;

        // Optional: For showing error messages in the view
        public string? ErrorMessage { get; set; }
    }
}

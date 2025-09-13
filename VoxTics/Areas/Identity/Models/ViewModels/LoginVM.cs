using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email or username is required.")]
        [StringLength(100, ErrorMessage = "Email or username cannot exceed 100 characters.")]
        [Display(Name = "Email or Username")]
        public string EmailORUserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

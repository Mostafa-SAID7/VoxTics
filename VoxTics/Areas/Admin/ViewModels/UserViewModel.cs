using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string? Phone { get; set; }

        [Display(Name = "Profile Image")]
        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }

        [Required]
        public string Role { get; set; } = "Customer";
    }
}

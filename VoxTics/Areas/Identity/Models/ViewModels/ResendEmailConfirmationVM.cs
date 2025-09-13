using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class ResendEmailConfirmationVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email or username is required.")]
        [StringLength(100, ErrorMessage = "Email or username cannot exceed 100 characters.")]
        [Display(Name = "Email or Username")]
        public string EmailORUserName { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class ConfirmOTPVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "OTP number is required.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "OTP must be between 4 and 6 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "OTP must contain only numbers.")]
        [Display(Name = "OTP Code")]
        public string OTPNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "User reference is required.")]
        public string ApplicationUserId { get; set; } = string.Empty;
    }
}

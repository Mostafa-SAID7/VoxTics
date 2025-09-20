namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class ChangePasswordVM
    {
        [Required, DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;
        public string UserId { get; internal set; }
    }
}

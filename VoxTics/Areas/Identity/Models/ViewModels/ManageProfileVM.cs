namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class ManageProfileVM
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
        public string? AvatarUrl { get; set; }
    }
}

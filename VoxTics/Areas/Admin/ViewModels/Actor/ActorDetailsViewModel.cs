namespace VoxTics.Areas.Admin.ViewModels.Actor
{
    public class ActorDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public bool IsActive { get; set; }

        public ICollection<string> Movies { get; set; } = new List<string>();
        public ICollection<string> SocialMediaLinks { get; set; } = new List<string>();
    }
}

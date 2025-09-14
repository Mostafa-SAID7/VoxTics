namespace VoxTics.Areas.Admin.ViewModels.Actor
{
    public class ActorTableViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int? Age { get; set; }
        public string? Nationality { get; set; }
        public string? ImageUrl { get; set; }
    }
}

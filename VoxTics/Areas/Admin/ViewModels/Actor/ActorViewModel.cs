namespace VoxTics.Areas.Admin.ViewModels.Actor
{
    public class ActorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
    }
}

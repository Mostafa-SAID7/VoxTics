namespace VoxTics.Models.ViewModels.Actor
{
    public class ActorVM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } // Changed Uri? to string? for simplicity


    }
}

namespace VoxTics.Models.ViewModels
{
    public class MovieCardVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }

        // Cinema & Category
        public string CategoryName { get; set; } = string.Empty;

    }
}

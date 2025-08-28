namespace VoxTics.Models
{
    public class Cinema
    {
        public int Id { get; set; }  // PK
        public string Name { get; set; }
        public string Description { get; set; }
        public string CinemaLogo { get; set; }
        public string Address { get; set; }

        // Navigation (if you later want Movies in a Cinema)
        public ICollection<Movie> Movies { get; set; }
    }
}

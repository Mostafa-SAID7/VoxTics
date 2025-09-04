namespace VoxTics.Models.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;

        // Navigation
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}

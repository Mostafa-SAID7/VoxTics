namespace VoxTics.Models.Entities
{
    public class Showtime
    {
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        [Required]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;

        // optional: seat map / capacity
        public int Capacity { get; set; } = 0;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

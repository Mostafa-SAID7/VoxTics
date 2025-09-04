using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Showtime
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public decimal TicketPrice { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; } = null!;

        // optional: seat map / capacity
        public int Capacity { get; set; } = 0;
        public int HallId { get; set; }
        public Hall Hall { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}

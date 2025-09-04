namespace VoxTics.Models.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Row { get; set; } = string.Empty;
        public int Number { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; } = null!;
    }
}

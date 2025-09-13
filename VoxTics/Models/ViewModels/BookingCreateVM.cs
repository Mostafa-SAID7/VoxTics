namespace VoxTics.Models.ViewModels
{
    public class BookingCreateVM
    {
        [Required] public int ShowtimeId { get; set; }
        [Required, Range(1, 20)] public int NumberOfTickets { get; set; }
        [Required] public string PaymentMethod { get; set; } = "CreditCard";
    }
}

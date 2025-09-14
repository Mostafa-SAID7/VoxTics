namespace VoxTics.Models.ViewModels
{
    public class BookingCreateVM
    {
        [Required]
        public int ShowtimeId { get; set; }

        [Required, Range(1, 20)]
        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }

        [Required, StringLength(20)]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = "CreditCard";

        // Optional enhancements
        [Display(Name = "Special Requests")]
        public string? Notes { get; set; }
    }
}

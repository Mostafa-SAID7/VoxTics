using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum NotificationType
    {
        [Display(Name = "Info")]
        [Description("General information")]
        Info = 0,

        [Display(Name = "Success")]
        [Description("Success message")]
        Success = 1,

        [Display(Name = "Warning")]
        [Description("Warning message")]
        Warning = 2,

        [Display(Name = "Error")]
        [Description("Error message")]
        Error = 3,

        [Display(Name = "Booking Confirmation")]
        [Description("Booking confirmation notification")]
        BookingConfirmation = 4,

        [Display(Name = "Booking Reminder")]
        [Description("Booking reminder notification")]
        BookingReminder = 5,

        [Display(Name = "Payment Reminder")]
        [Description("Payment reminder notification")]
        PaymentReminder = 6,

        [Display(Name = "Cancellation")]
        [Description("Cancellation notification")]
        Cancellation = 7,

        [Display(Name = "Refund")]
        [Description("Refund notification")]
        Refund = 8
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum PaymentStatus
    {
        [Display(Name = "Pending")]
        [Description("Payment is being processed")]
        Pending = 0,

        [Display(Name = "Completed")]
        [Description("Payment has been completed successfully")]
        Completed = 1,

        [Display(Name = "Processing")]
        Processing = 2,

        [Display(Name = "Failed")]
        [Description("Payment has failed")]
        Failed = 3,

        [Display(Name = "Refunded")]
        [Description("Payment has been refunded")]
        Refunded = 4
    }
}

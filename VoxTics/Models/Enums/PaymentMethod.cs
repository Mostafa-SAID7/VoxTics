namespace VoxTics.Models.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Undefined")] Undefined = 0,
        [Display(Name = "Credit Card")] CreditCard = 1,
        [Display(Name = "PayPal")] Paypal = 2,
        [Display(Name = "Stripe")] Stripe = 3,
        [Display(Name = "Cash")] Cash = 4
    }

}

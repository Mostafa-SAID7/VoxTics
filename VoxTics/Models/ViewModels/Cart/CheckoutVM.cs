namespace VoxTics.Models.ViewModels.Cart
{
    public class CheckoutVM
    {
        // User information
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        // Cart items (tickets)
        public List<CheckoutItemVM> Items { get; set; } = new();

        // Pricing summary
        public decimal Subtotal { get; set; }          // Sum of ticket prices before discounts
        public decimal DiscountAmount { get; set; }    // Total discount applied
        public decimal FinalTotal { get; set; }        // Final amount to pay after discounts
        public decimal TaxAmount { get; set; }         // (Optional) Taxes applied

        // Payment details
        public PaymentMethod PaymentMethod { get; set; }
        public bool UseWalletBalance { get; set; }     // If your app supports wallet/credit

        // Convenience fields for UI
        public DateTime CheckoutDate { get; set; } = DateTime.Now;
        public bool HasDiscount => DiscountAmount > 0;
        public bool IsCartEmpty => Items.Count == 0;
    }
}

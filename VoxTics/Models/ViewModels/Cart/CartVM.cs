using VoxTics.Models.Entities;

namespace VoxTics.Models.ViewModels.Cart
{
    public class CartVM
    {
        public List<CartItemVM> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}

namespace VoxTics.Models.ViewModels
{
    /// <summary>
    /// Base ViewModel class for shared properties across all ViewModels
    /// </summary>
    public abstract class BaseViewModel
    {
        
        public int? Id { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; } = true;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

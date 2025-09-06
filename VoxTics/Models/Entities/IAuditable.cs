using System;

namespace VoxTics.Models.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }   // Soft delete timestamp
        bool IsDeleted { get; set; }
    }
}

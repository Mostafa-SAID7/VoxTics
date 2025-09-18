using System;

namespace VoxTics.Models.Entities
{
    public abstract class BaseEntity 
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Soft delete properties
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Method to soft delete
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        // Method to restore entity
        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}

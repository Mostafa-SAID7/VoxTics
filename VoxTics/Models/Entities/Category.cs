using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Category : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(60)]
        public string Slug { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

    }
}

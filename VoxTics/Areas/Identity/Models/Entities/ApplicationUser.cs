using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using VoxTics.Areas.Identity.Models.Enums;

namespace VoxTics.Areas.Identity.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string Address { get; set; } = string.Empty;
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }

        // Read-only Skills
        public List<string> Skills { get; } = new();

        // Changed to System.Uri
        public Uri? AvatarUrl { get; set; }

        // Read-only navigation properties
        public ICollection<UserOTP> UserOTPs { get; } = new List<UserOTP>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public int Age => DateOfBirth.HasValue ? (int)((DateTime.UtcNow - DateOfBirth.Value).TotalDays / 365.25) : 0;

        public string FullAddress => $"{Street}, {City}, {State}, {ZipCode}".Trim(',', ' ');
    }
}

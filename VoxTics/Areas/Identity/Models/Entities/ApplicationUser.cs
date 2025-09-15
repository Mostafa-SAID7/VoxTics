// VoxTics.Areas.Identity.Models.Entities/ApplicationUser.cs
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

        public List<string> Skills { get; } = new();
        public Uri? AvatarUrl { get; set; }

        // Navigation properties
        public ICollection<UserOTP> UserOTPs { get; } = new List<UserOTP>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        // Backwards-compatibility collection (if you still use the simpler mapping)
        public ICollection<UserMovieWatchlist> UserMovieWatchlists { get; set; } = new List<UserMovieWatchlist>();

        public int Age => DateOfBirth.HasValue ? (int)((DateTime.UtcNow - DateOfBirth.Value).TotalDays / 365.25) : 0;
        public string FullAddress => $"{Street}, {City}, {State}, {ZipCode}".Trim(',', ' ');

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

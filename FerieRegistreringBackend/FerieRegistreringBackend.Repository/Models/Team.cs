using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int LeaderUserId { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation: medlemmer ( Users )
        public ICollection<User> Members { get; set; } = new List<User>();
    }
}

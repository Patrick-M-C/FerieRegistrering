using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public class TeamCreateDto
    {
        [Required, MaxLength(120)] public string Name { get; set; } = string.Empty;
        [MaxLength(500)] public string? Description { get; set; }
        public int LeaderUserId { get; set; }
    }

    public class TeamUpdateDto : TeamCreateDto
    {
        [Required] public int TeamId { get; set; }
    }

    public class TeamResponseDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? LeaderUserId { get; set; }
        public System.DateTime CreatedAtUtc { get; set; }
        public IEnumerable<object> Members { get; set; } = new List<object>();
    }
}
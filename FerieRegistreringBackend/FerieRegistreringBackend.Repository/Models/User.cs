using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]

        [JsonIgnore]
        
        public string Password { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
        [JsonIgnore]
        public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
    }

}

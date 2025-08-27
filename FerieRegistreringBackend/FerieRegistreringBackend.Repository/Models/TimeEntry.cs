using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Models
{
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public double TotalHours => (EndTime - StartTime).TotalHours;
        public User? User { get; set; } 
    }
}

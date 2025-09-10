using System;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public enum AbsenceType
    {
        Sick = 0,
        ChildSick = 1,
        Course = 2,
        ParentalLeave = 3,
        Other = 99
    }

    public class Absence
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public AbsenceType Type { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
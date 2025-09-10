using System;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public class AbsenceCreateDto
    {
        [Required] public AbsenceType Type { get; set; }
        [Required] public DateOnly Date { get; set; }
        [MaxLength(500)] public string? Note { get; set; }
    }

    public class AbsenceResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public AbsenceType Type { get; set; }
        public DateOnly Date { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
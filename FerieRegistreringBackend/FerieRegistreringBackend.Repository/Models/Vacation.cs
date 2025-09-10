using System;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public enum VacationStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

    public class Vacation
    {
        public int Id { get; set; }

        [Required] public DateOnly StartDate { get; set; }
        [Required] public DateOnly EndDate   { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = false;

        public VacationStatus Status { get; set; } = VacationStatus.Pending;
        public string? ManagerComment { get; set; }

        // Relation til ansøger
        [Required] public int UserId { get; set; }
        public User? User { get; set; }

        public int? DecidedByUserId { get; set; }
        public DateTime CreatedAtUtc    { get; set; } = DateTime.UtcNow;
        public DateTime? DecidedAtUtc   { get; set; }
    }
}
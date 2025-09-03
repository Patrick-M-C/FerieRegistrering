using System;
using System.ComponentModel.DataAnnotations;

namespace FerieRegistreringBackend.Repository.Models
{
    public class VacationRequestDto
    {
        [Required] public DateOnly StartDate { get; set; }
        [Required] public DateOnly EndDate   { get; set; }
        [MaxLength(500)] public string? Reason { get; set; }
    }

    public class VacationDecisionDto
    {
        [MaxLength(500)] public string? ManagerComment { get; set; }
    }

    public class VacationResponseDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public VacationStatus Status { get; set; }
        public bool IsApproved { get; set; }
        public int UserId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? DecidedAtUtc { get; set; }
        public string? ManagerComment { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public bool IsApproved { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

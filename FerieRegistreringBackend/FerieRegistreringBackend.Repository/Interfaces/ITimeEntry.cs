using FerieRegistreringBackend.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface ITimeEntry
    {
        Task<IEnumerable<TimeEntry>> GetAllAsync();
        Task<TimeEntry?> GetByIdAsync(int id);
        Task<IEnumerable<TimeEntry>> GetByUserIdAsync(int userId);
        Task<TimeEntry> AddAsync(TimeEntry timeEntry);
        Task<TimeEntry> UpdateAsync(TimeEntry timeEntry);
        Task<bool> DeleteAsync(int id);
    }
}

using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Entities
{
    public class TimeEntryRepo : ITimeEntry
    {
        private readonly DatabaseContext _context;

        public TimeEntryRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TimeEntry> AddAsync(TimeEntry timeEntry)
        {
            _context.TimeEntries.Add(timeEntry);
            await _context.SaveChangesAsync();
            return timeEntry;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var timeEntry = await _context.TimeEntries.FindAsync(id);
            if (timeEntry == null) return false;
     
            _context.TimeEntries.Remove(timeEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TimeEntry>> GetAllAsync()
        {
            return await _context.TimeEntries.Include(v => v.User).ToListAsync();
        }

        public async Task<TimeEntry?> GetByIdAsync(int id)
        {
            return await _context.TimeEntries.Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<TimeEntry>> GetByUserIdAsync(int userId)
        {
            return await _context.TimeEntries.Where(v => v.UserId == userId).ToListAsync();

        }

        public async Task<TimeEntry> UpdateAsync(TimeEntry timeEntry)
        {
            _context.TimeEntries.Update(timeEntry);
            await _context.SaveChangesAsync();
            return timeEntry;
        }
    }
}

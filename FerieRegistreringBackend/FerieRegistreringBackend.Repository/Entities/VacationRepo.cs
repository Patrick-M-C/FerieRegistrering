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
    public class VacationRepo : IVacation
    {
        private readonly DatabaseContext _context;

        public VacationRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vacation>> GetAllAsync()
        {
            return await _context.Vacations.Include(v => v.User).ToListAsync();
        }

        public async Task<Vacation?> GetByIdAsync(int id)
        {
            return await _context.Vacations.Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vacation>> GetByUserIdAsync(int userId)
        {
            return await _context.Vacations.Where(v => v.UserId == userId).ToListAsync();
        }

        public async Task<Vacation> AddAsync(Vacation vacation)
        {
            _context.Vacations.Add(vacation);
            await _context.SaveChangesAsync();
            return vacation;
        }

        public async Task<Vacation> UpdateAsync(Vacation vacation)
        {
            _context.Vacations.Update(vacation);
            await _context.SaveChangesAsync();
            return vacation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null) return false;

            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

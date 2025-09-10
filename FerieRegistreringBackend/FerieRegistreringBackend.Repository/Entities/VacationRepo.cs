using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FerieRegistreringBackend.Repository.Entities
{
    public class VacationRepo : IVacation
    {
        private readonly DatabaseContext _db;
        public VacationRepo(DatabaseContext db) { _db = db; }

        public async Task<Vacation> CreateAsync(int userId, Vacation v)
        {
            v.UserId = userId;
            v.Status = VacationStatus.Pending;
            v.IsApproved = false;
            _db.Vacations.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task<IEnumerable<Vacation>> GetMineAsync(int userId)
        {
            return await _db.Vacations
                .Include(v => v.User)
                .Where(v => v.UserId == userId)
                .OrderByDescending(v => v.CreatedAtUtc)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vacation>> GetPendingAsync()
        {
            return await _db.Vacations
                .Include(v => v.User)
                .Where(v => v.Status == VacationStatus.Pending)
                .OrderBy(v => v.StartDate)
                .ToListAsync();
        }

        public Task<Vacation?> GetByIdAsync(int id)
        {
            return _db.Vacations
                .Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vacation?> ApproveAsync(int id, int leaderUserId, string? comment)
        {
            var v = await _db.Vacations.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (v == null) return null;
            v.Status = VacationStatus.Approved;
            v.IsApproved = true;
            v.ManagerComment = comment;
            v.DecidedByUserId = leaderUserId;
            v.DecidedAtUtc = System.DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task<Vacation?> RejectAsync(int id, int leaderUserId, string? comment)
        {
            var v = await _db.Vacations.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (v == null) return null;
            v.Status = VacationStatus.Rejected;
            v.IsApproved = false;
            v.ManagerComment = comment;
            v.DecidedByUserId = leaderUserId;
            v.DecidedAtUtc = System.DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return v;
        }
    }
}
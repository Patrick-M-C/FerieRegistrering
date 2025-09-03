using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FerieRegistreringBackend.Repository.Entities
{
    public class AbsenceRepo : IAbsence
    {
        private readonly DatabaseContext _db;
        public AbsenceRepo(DatabaseContext db) { _db = db; }

        public async Task<Absence> CreateAsync(int userId, Absence a)
        {
            a.UserId = userId;
            _db.Absences.Add(a);
            await _db.SaveChangesAsync();
            return a;
        }

        public async Task<IEnumerable<Absence>> GetMineAsync(int userId, DateOnly? from = null, DateOnly? to = null)
        {
            var q = _db.Absences.Include(x => x.User).Where(x => x.UserId == userId);
            if (from.HasValue) q = q.Where(x => x.Date >= from.Value);
            if (to.HasValue) q = q.Where(x => x.Date <= to.Value);
            return await q.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<IEnumerable<Absence>> GetAllAsync(DateOnly? from = null, DateOnly? to = null, int? userId = null)
        {
            var q = _db.Absences.Include(x => x.User).AsQueryable();
            if (userId.HasValue) q = q.Where(x => x.UserId == userId.Value);
            if (from.HasValue) q = q.Where(x => x.Date >= from.Value);
            if (to.HasValue) q = q.Where(x => x.Date <= to.Value);
            return await q.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id, int actingUserId, bool actingIsLeader)
        {
            var a = await _db.Absences.FirstOrDefaultAsync(x => x.Id == id);
            if (a == null) return false;
            if (!actingIsLeader && a.UserId != actingUserId) return false; // kun leder eller ejeren må slette
            _db.Absences.Remove(a);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<Absence?> GetByIdAsync(int id)
        {
            return _db.Absences.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
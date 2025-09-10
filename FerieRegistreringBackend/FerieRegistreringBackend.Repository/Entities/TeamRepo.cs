using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Database;
using FerieRegistreringBackend.Repository.Interfaces;
using FerieRegistreringBackend.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FerieRegistreringBackend.Repository.Entities
{
    public class TeamRepo : ITeam
    {
        private readonly DatabaseContext _db;
        public TeamRepo(DatabaseContext db) { _db = db; }

        public async Task<Team> CreateAsync(Team team)
        {
            _db.Teams.Add(team);
            await _db.SaveChangesAsync();
            return team;
        }

        public async Task<Team?> GetByIdAsync(int teamId, bool includeMembers = true)
        {
            var q = _db.Teams.AsQueryable();
            if (includeMembers) q = q.Include(t => t.Members);
            return await q.FirstOrDefaultAsync(t => t.TeamId == teamId);
        }

        public async Task<IEnumerable<Team>> GetAllAsync(bool includeInactive = false)
        {
            return await _db.Teams
                .Where(t => includeInactive || t.IsActive)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<Team?> UpdateAsync(Team team)
        {
            var dbTeam = await _db.Teams.FirstOrDefaultAsync(t => t.TeamId == team.TeamId);
            if (dbTeam == null) return null;
            dbTeam.Name = team.Name;
            dbTeam.Description = team.Description;
            dbTeam.LeaderUserId = team.LeaderUserId;
            await _db.SaveChangesAsync();
            return dbTeam;
        }

        public async Task<bool> SoftDeleteAsync(int teamId)
        {
            var t = await _db.Teams.FindAsync(teamId);
            if (t == null) return false;
            t.IsActive = false;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMemberAsync(int teamId, int userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var team = await _db.Teams.FirstOrDefaultAsync(t => t.TeamId == teamId);
            if (user == null || team == null) return false;
            user.TeamId = teamId;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveMemberAsync(int teamId, int userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null || user.TeamId != teamId) return false;
            user.TeamId = null;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Team?> GetMyTeamAsync(int userId)
        {
            return await _db.Teams
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.Members.Any(m => m.Id == userId));
        }
    }
}
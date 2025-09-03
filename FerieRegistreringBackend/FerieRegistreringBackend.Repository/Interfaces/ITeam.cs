using System.Collections.Generic;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Models;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface ITeam
    {
        Task<Team> CreateAsync(Team team);
        Task<Team?> GetByIdAsync(int teamId, bool includeMembers = true);
        Task<IEnumerable<Team>> GetAllAsync(bool includeInactive = false);
        Task<Team?> UpdateAsync(Team team);
        Task<bool> SoftDeleteAsync(int teamId);
        Task<bool> AddMemberAsync(int teamId, int userId);
        Task<bool> RemoveMemberAsync(int teamId, int userId);
        Task<Team?> GetMyTeamAsync(int userId);
    }
}
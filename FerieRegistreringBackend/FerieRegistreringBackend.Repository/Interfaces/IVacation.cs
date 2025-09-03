using System.Collections.Generic;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Models;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface IVacation
    {
        Task<Vacation> CreateAsync(int userId, Vacation v);
        Task<IEnumerable<Vacation>> GetMineAsync(int userId);
        Task<IEnumerable<Vacation>> GetPendingAsync();
        Task<Vacation?> GetByIdAsync(int id);
        Task<Vacation?> ApproveAsync(int id, int leaderUserId, string? comment);
        Task<Vacation?> RejectAsync(int id, int leaderUserId, string? comment);
    }
}
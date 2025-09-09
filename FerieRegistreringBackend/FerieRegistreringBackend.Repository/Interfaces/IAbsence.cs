using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Models;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface IAbsence
    {
        Task<Absence> CreateAsync(int userId, Absence a);
        Task<IEnumerable<Absence>> GetMineAsync(int userId, DateOnly? from = null, DateOnly? to = null);
        Task<IEnumerable<Absence>> GetAllAsync(DateOnly? from = null, DateOnly? to = null, int? userId = null);
        Task<bool> DeleteAsync(int id, int actingUserId, bool actingIsLeader);
        Task<Absence?> GetByIdAsync(int id);
    }
}
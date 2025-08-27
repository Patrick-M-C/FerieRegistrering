using FerieRegistreringBackend.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface IVacation
    {
        Task<IEnumerable<Vacation>> GetAllAsync();
        Task<Vacation?> GetByIdAsync(int id);
        Task<IEnumerable<Vacation>> GetByUserIdAsync(int userId);
        Task<Vacation> AddAsync(Vacation vacation);
        Task<Vacation> UpdateAsync(Vacation vacation);
        Task<bool> DeleteAsync(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FerieRegistreringBackend.Repository.Models;

namespace FerieRegistreringBackend.Repository.Interfaces
{
    public interface IAuth
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<AuthResponse> RegisterAsync(RegisterRequest request, User? actingUser = null);
    }
}

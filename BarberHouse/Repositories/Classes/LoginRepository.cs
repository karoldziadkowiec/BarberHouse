using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Models.DTOs;
using BarberHouse.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Repositories.Classes
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int userId)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<User> GetUserByEmail(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}

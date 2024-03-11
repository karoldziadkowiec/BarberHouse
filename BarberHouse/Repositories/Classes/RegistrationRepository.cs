using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Models.DTOs;
using BarberHouse.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Repositories.Classes
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int userId)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<User> GetUserByEmail(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<bool> CheckIfEmailExist(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null;
        }

        public async Task<Group> GetGroupByName(string groupName)
            => await _context.Groups.FirstOrDefaultAsync(g => g.Name == groupName);

        public async Task<User> RegisterUser(RegisterDTO model)
        {
            string groupName = "User";
            var group = await GetGroupByName(groupName);
            var newUser = new User(model.Name, model.Surname, model.Email, model.Password, model.Phone, model.Birthday, model.Address, group.Id);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}

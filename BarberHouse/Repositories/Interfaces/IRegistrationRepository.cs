using BarberHouse.Models;
using BarberHouse.Models.DTOs;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
        Task<User> RegisterUser(RegisterDTO model);
    }
}

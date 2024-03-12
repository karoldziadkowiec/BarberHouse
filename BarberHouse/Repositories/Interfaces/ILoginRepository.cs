using BarberHouse.Models;
using BarberHouse.Models.DTOs;

namespace BarberHouse.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
    }
}

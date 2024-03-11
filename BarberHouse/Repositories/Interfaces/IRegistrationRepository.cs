using BarberHouse.Models;
using BarberHouse.Models.DTOs;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string email);
        Task<bool> CheckIfEmailExist(string email);
        Task<Group> GetGroupByName(string groupName);
        Task<User> RegisterUser(RegisterDTO model);
    }
}

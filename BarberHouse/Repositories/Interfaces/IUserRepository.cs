using BarberHouse.Models;

namespace BarberHouse.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> GetUsersByGroupId(int groupId);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task RemoveUser(int userId);
        Task<byte[]> GetUsersCsvBytes();
        Task<IEnumerable<User>> SearchUser(string searchTerm);
        Task<IEnumerable<User>> SearchPartial(string searchTerm);
        Task ModifyToBarber(User user);
        Task RemoveFromBarber(User user);
    }
}

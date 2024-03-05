using BarberHouse.Database;
using BarberHouse.Repositories.Interfaces;

namespace BarberHouse.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

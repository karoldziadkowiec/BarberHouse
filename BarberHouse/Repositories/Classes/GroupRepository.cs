using BarberHouse.Database;
using BarberHouse.Repositories.Interfaces;

namespace BarberHouse.Repositories.Classes
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

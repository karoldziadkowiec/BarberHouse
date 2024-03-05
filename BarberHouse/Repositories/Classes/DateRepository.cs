using BarberHouse.Database;
using BarberHouse.Repositories.Interfaces;

namespace BarberHouse.Repositories.Classes
{
    public class DateRepository : IDateRepository
    {
        private readonly AppDbContext _context;

        public DateRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

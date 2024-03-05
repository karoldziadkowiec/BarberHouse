using BarberHouse.Database;
using BarberHouse.Repositories.Interfaces;

namespace BarberHouse.Repositories.Classes
{
    public class VisitRepository : IVisitRepository
    {
        private readonly AppDbContext _context;

        public VisitRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

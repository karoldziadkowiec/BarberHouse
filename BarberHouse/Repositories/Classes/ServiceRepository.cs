using BarberHouse.Database;
using BarberHouse.Repositories.Interfaces;

namespace BarberHouse.Repositories.Classes
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

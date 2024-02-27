using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}


    }
}

using BarberHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

using BarberHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}

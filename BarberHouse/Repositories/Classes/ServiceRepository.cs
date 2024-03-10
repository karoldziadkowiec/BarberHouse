using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Repositories.Classes
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Service>> GetAllServices()
            => await Task.FromResult(_context.Services.OrderBy(s => s.Id));

        public async Task<Service> GetServiceById(int serviceId)
            => await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);

        public async Task AddService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateService(Service service)
        {
            var existingService = await _context.Services.FindAsync(service.Id);

            if (existingService != null)
            {
                existingService.Name = service.Name;
                existingService.Description = service.Description;
                existingService.Value = service.Value;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveService(int serviceId)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}

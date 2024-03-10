using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Repositories.Classes
{
    public class VisitRepository : IVisitRepository
    {
        private readonly AppDbContext _context;

        public VisitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Visit>> GetAllVisits()
           => await Task.FromResult(_context.Visits.OrderBy(v => v.Id));

        public async Task<Visit> GetVisitById(int visitId)
            => await _context.Visits.FirstOrDefaultAsync(v => v.Id == visitId);

        public async Task AddVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVisit(Visit visit)
        {
            var existingVisit = await _context.Visits.FindAsync(visit.Id);

            if (existingVisit != null)
            {
                existingVisit.UserId = visit.UserId;
                existingVisit.BarberId = visit.BarberId;
                existingVisit.DateId = visit.DateId;
                existingVisit.ServiceId = visit.ServiceId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveVisit(int visitId)
        {
            var visit = await _context.Visits.FirstOrDefaultAsync(v => v.Id == visitId);
            if (visit != null)
            {
                _context.Visits.Remove(visit);
                await _context.SaveChangesAsync();
            }
        }
    }
}

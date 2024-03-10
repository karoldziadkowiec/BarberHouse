using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse.Repositories.Classes
{
    public class DateRepository : IDateRepository
    {
        private readonly AppDbContext _context;

        public DateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Date>> GetAllDates()
            => await Task.FromResult(_context.Dates.OrderBy(d => d.Id));

        public async Task<Date> GetDateById(int dateId)
            => await _context.Dates.FirstOrDefaultAsync(d => d.Id == dateId);

        public async Task AddDate(Date date)
        {
            _context.Dates.Add(date);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDate(Date date)
        {
            var existingDate = await _context.Dates.FindAsync(date.Id);

            if (existingDate != null)
            {
                existingDate.VisitDate = date.VisitDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveDate(int dateId)
        {
            var date = await _context.Dates.FirstOrDefaultAsync(d => d.Id == dateId);
            if (date != null)
            {
                _context.Dates.Remove(date);
                await _context.SaveChangesAsync();
            }
        }
    }
}
